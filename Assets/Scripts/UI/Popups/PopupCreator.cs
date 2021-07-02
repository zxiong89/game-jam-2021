using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject popupContainerPrefab;

    /// <summary>
    /// Creates and displays a popup
    /// </summary>
    /// <param name="args">The args for the popup</param>
    public void CreatePopup(PopupEventArgs args)
    {
        Debug.Log("Makin a popup!");
        var popupObj = Instantiate(popupContainerPrefab, this.transform);
        PopupDisplay popup = popupObj.GetComponent<PopupDisplay>();
        popup.DisplayPopup(args);
    }
}
