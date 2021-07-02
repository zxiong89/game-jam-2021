using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject contentContainer;

    private GameObject content;

    [SerializeField]
    private GameObject buttonsContainer;

    [SerializeField]
    private GameObject buttonPrefab;

    /// <summary>
    /// Show a popup with only a close button.
    /// </summary>
    /// <param name="popupContent">The content to display. This should be an already instantiated game object</param>
    public void DisplayClosePopup(GameObject popupContent)
    {
        LoadContent(popupContent);
        LoadButtons(null, "Close");
    }

    /// <summary>
    /// Shows a popup with an accept and a cancel button.
    /// </summary>
    /// <param name="popupContent">The content to display. This should be an already instantiated game object</param>
    /// <param name="acceptCallback">The function called when the accept button is clicked. The content is passed back in this</param>
    public void DisplayAcceptCancelPopup(GameObject popupContent, Action<GameObject> acceptCallback)
    {
        LoadContent(popupContent);
        LoadButtons(acceptCallback, "Accept", "Cancel");
    }

    private void LoadContent(GameObject popupContent)
    {
        popupContent.transform.parent = contentContainer.transform;
        content = popupContent;
    }

    private void LoadButtons(Action<GameObject> acceptFunc, params string[] buttons)
    {
        for (int i = 0; i < buttons.Length; i++)
        { 
            GameObject buttonObj = Instantiate(buttonPrefab, buttonsContainer.transform);
            var button = buttonObj.GetComponent<BaseButton>();
            button.SetText(buttons[i]);
            if(acceptFunc != null && i == 0)
            {
                button.SetCallback(() => acceptFunc(content));
            }
        }
    }
}
