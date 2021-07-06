using System;
using UnityEngine;
using UnityEngine.UI;

public class PartyUnitSelection : MonoBehaviour
{
    [Header("Display")]

    [SerializeField]
    private UnitDisplay unitDisplay;

    [SerializeField]
    private GameObject unitSummary;

    [Header("Data")]

    [SerializeField]
    private Guild guild;

    [SerializeField]
    public PartyData currentParty;

    [SerializeField]
    private bool isFrontline = true;

    [SerializeField]
    private PartyUnitSelection higherPrioritySelection;

    [Header("Events")]

    [SerializeField]
    private PartyEvent partyUpdatedEvent;

    [Header("Pop-up")]

    [SerializeField]
    private PopupEvent createPopupEvent;

    [SerializeField]
    private PartyUnitSelectionPopup popupPrefab;

    public Unit Unit
    {
        get => unitDisplay?.currentUnit;
        set
        {
            if (unitDisplay != null)
            {
                unitDisplay.DisplayUnit(value);
                unitSummary.SetActive(unitDisplay.currentUnit != null);
            }
        }
    }

    public void StartUnitSelection()
    {
        var popup = GameObject.Instantiate<PartyUnitSelectionPopup>(popupPrefab);
        popup.PopulatePartySummary(currentParty.Party);
        popup.PopulateRoster(Unit, isFrontline);

        createPopupEvent.Raise(new PopupEventArgs()
        {
            Content = popup.gameObject,
            AcceptCallback = (GameObject gameObject) => SwitchOutUnit(popup),
            AcceptTextOverride = "Swap",
            CancelCallback = (GameObject gameObject) => RaiseAndUpdatePartyDisplay()
        });
    }

    public void SwitchOutUnit(PartyUnitSelectionPopup popup)
    {
        if (popup == null) return;
        var unit = popup.GetSelectedUnit();
        if (unit == null) return;

        if (!CanSetHigherLinePriority(unit)) 
        {
            currentParty.Party.RemoveUnit(Unit);
            Unit = unit; 
        }
        if (isFrontline) currentParty.Party.AddToFrontLine(unit);
        else currentParty.Party.AddToBackLine(unit);
        RaiseAndUpdatePartyDisplay();
    }
    
    public void RaiseAndUpdatePartyDisplay()
    {
        partyUpdatedEvent.Raise(new PartyEventArgs()
        {
            Party = currentParty.Party
        });
    }

    public bool CanSetHigherLinePriority(Unit unit)
    {
        if (higherPrioritySelection != null)
        {
            if (higherPrioritySelection.CanSetHigherLinePriority(unit)) return true;
            if (higherPrioritySelection.Unit == null)
            {
                higherPrioritySelection.Unit = unit;
                return true;
            }
        }
        return false;

    }
}
