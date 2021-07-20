using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject popupContainerPrefab;

    [SerializeField]
    private GameObject InteractionShield;

    private void OnEnable()
    {
        PopupMessage.SetPopupCreator(this);
    }

    private void OnDisable()
    {
        PopupMessage.RemovePopupCreator(this);
    }

    /// <summary>
    /// Creates and displays a popup
    /// </summary>
    /// <param name="args">The args for the popup</param>
    public void CreatePopup(PopupEventArgs args)
    {
        var popupObj = Instantiate(popupContainerPrefab, this.transform);
        PopupDisplay popup = popupObj.GetComponent<PopupDisplay>();
        InteractionShield.SetActive(true);
        popup.DisplayPopup(args, this);
        InteractionShield.transform.SetSiblingIndex(transform.childCount - 2);
    }

    public void PopupClosed()
    {
        if (transform.childCount == 2)
        {
            InteractionShield.SetActive(false);
        }
        else
        {
            InteractionShield.transform.SetSiblingIndex(transform.childCount - 3);
        }

    }
}
