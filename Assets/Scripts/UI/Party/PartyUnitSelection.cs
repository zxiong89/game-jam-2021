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
    private PartyUnitSelector selector;

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
        var selector = GameObject.Instantiate<PartyUnitSelector>(this.selector);
        selector.PopulateRoster(Unit);

        var scrollRect = selector.GetComponent<ScrollRect>();
        if (scrollRect != null)
        {
            scrollRect.verticalScrollbar.value = 0;
        }

        createPopupEvent.Raise(new PopupEventArgs()
        {
            Content = selector.gameObject,
            AcceptCallback = (GameObject gameObject) => SwitchOutUnit(selector),
            AcceptTextOverride = "Switch"
        });
    }

    public void SwitchOutUnit(PartyUnitSelector selector)
    {
        if (selector == null) return;
        var unit = selector.GetSelectedUnit();
        if (unit == null) return;

        if (!CanSetHigherLinePriority(unit)) 
        {
            currentParty.Party.RemoveUnit(Unit);
            Unit = unit; 
        }
        if (isFrontline) currentParty.Party.AddToFrontLine(unit);
        else currentParty.Party.AddToBackLine(unit);
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
