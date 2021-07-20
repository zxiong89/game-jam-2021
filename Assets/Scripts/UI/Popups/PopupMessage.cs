using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PopupMessage
{
    private static PopupCreator popupCreator;

    public static void SetPopupCreator(PopupCreator newCreator)
    {
        if (popupCreator != null) throw new System.Exception("Popup creator already set.");
        popupCreator = newCreator;
    }

    public static void RemovePopupCreator(PopupCreator creatorToRemove)
    {
        if (popupCreator != creatorToRemove) throw new System.Exception("Tried to remove a popup creator that wasn't in use.");
        popupCreator = null;
    }

    public static void ShowPopup(PopupEventArgs args)
    {
        if (popupCreator == null) throw new System.Exception("Popup creator has not been set.");
        popupCreator.CreatePopup(args);
    }

}
