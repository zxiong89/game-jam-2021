using System;
using System.Collections.Generic;
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

    private PopupCreator parent;

    public void DisplayPopup(PopupEventArgs args, PopupCreator newParent)
    {
        parent = newParent;
        LoadContent(args.Content);
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

    private void LoadContent(GameObject popupContent)
    {
        popupContent.transform.SetParent(contentContainer.transform, false);
        content = popupContent;
    }

    private void LoadButtons(List<Action<GameObject>> acceptFunc, List<string> buttons)
    {
        for (int i = 0; i < buttons.Count; i++)
        { 
            GameObject buttonObj = Instantiate(buttonPrefab, buttonsContainer.transform);
            var button = buttonObj.GetComponent<BaseButton>();
            button.SetText(buttons[i]);
            if(acceptFunc != null && i == 0)
            {
                button.SetCallback(() => acceptFunc[i](content));
            }
        }
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
