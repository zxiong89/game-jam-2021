using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject popupContainerPrefab;

    [SerializeField]
    private GameObject InteractionShield;

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
    }

    public void PopupClosed()
    {
        InteractionShield.SetActive(false);
    }
}
