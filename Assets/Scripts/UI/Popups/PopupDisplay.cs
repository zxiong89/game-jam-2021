using System;
using UnityEngine;
using UnityEngine.UI;

public class PopupDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject contentContainer;

    private GameObject content;

    [SerializeField]
    private GameObject buttonsContainer;

    [SerializeField]
    private GameObject buttonPrefab;

    [SerializeField]
    private GameObject textPopupPrefab;

    [SerializeField]
    private GameEvent pauseGameEvent;

    [SerializeField]
    private GameEvent resumeGameEvent;

    private PopupCreator parent;

    private PopupEventArgs popupArgs;

    public void DisplayPopup(PopupEventArgs args, PopupCreator newParent)
    {
        popupArgs = args;
        parent = newParent;

        if (args.PausesTime) pauseGameEvent.Raise();

        if (args.Content)
        {
            LoadContent(args.Content);
        }
        else
        {
            LoadTextPopup(args);
        }

        if(args.AcceptCallback != null)
        {
            AddAcceptButton(GetButtonText(args.AcceptTextOverride, "Accept"), args.AcceptCallback);
            AddCloseButton(GetButtonText(args.CloseTextOverride, "Cancel"), args.CancelCallback);
        }
        else
        {
            AddCloseButton(GetButtonText(args.CloseTextOverride, "Close"), args.CancelCallback);
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }

    private string GetButtonText(string overrideText, string defaultText)
    {
        return (overrideText == null) ? defaultText : overrideText;
    }

    private void LoadTextPopup(PopupEventArgs args)
    {
        GameObject textPopupObj = Instantiate(textPopupPrefab, contentContainer.transform);
        TextPopup textPopup = textPopupObj.GetComponent<TextPopup>();
        textPopup.SetText(args.Text);
        content = textPopupObj;
    }

    private void LoadContent(GameObject popupContent)
    {
        popupContent.transform.SetParent(contentContainer.transform, false);
        content = popupContent;
    }

    private BaseButton CreateButton(string buttonText)
    {
        GameObject buttonObj = Instantiate(buttonPrefab, buttonsContainer.transform);
        var button = buttonObj.GetComponent<BaseButton>();
        button.SetText(buttonText);
        return button;
    }

    private void AddCloseButton(string buttonText, Action<GameObject> callback = null)
    {
        BaseButton button = CreateButton(buttonText);
        if (callback == null)
        {
            button.SetCallback(ClosePopup);
        }
        else
        {
            button.SetCallback(() =>
            {
                callback(content);
                ClosePopup();
            });
        }
    }

    private void ClosePopup()
    {
        if (popupArgs.PausesTime) resumeGameEvent.Raise();
        parent.PopupClosed();
        Destroy(gameObject);
    }

    private void AddAcceptButton(string buttonText, Action<GameObject> callback)
    {
        BaseButton button = CreateButton(buttonText);
        button.SetCallback(() => {
            callback(content);
            ClosePopup();
        });
    }
}
