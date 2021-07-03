using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyUnitSelector : MonoBehaviour
{
    public PartyUnitSelection Selection;

    public PartyData CurrentParty;

    [SerializeField]
    private Guild guild;

    [SerializeField]
    private PartyEvent unitSelectedEvent;

    [SerializeField]
    private UnitEvent onUnitSelected;

    [SerializeField]
    private Toggle selectorPrefab;

    [SerializeField]
    private Transform contentContainer;

    public void PopulateRoster()
    {
        if (guild == null) return;
        if (CurrentParty == null && CurrentParty.Party == null) return;

        instantiateUnitSelector(Selection?.Unit, true);

        foreach (Unit u in CurrentParty.Party.FrontLine)
        {
            if (u == Selection?.Unit) return;
            instantiateUnitSelector(Selection.Unit, true);
        }

        foreach (Unit u in CurrentParty.Party.BackLine)
        {
            if (u == Selection?.Unit) return;
            instantiateUnitSelector(Selection.Unit, true);
        }

        foreach (Unit u in guild.Roster)
        {
            if (CurrentParty.Party.Contains(u)) continue;
            instantiateUnitSelector(u, false);
        }
    }

    private void instantiateUnitSelector(Unit unit, bool isOn = false)
    {
        if (unit == null) return;
        var obj = GameObject.Instantiate<Toggle>(selectorPrefab, contentContainer);
        obj.isOn = isOn;
        var unitDisplay = obj.GetComponent<UnitDisplay>();
        if (unitDisplay == null) return;
        unitDisplay.DisplayUnit(unit);
    }

    public void OnUnitSelected(Unit unit)
    {
        unitSelectedEvent.Raise(new PartyEventArgs()
        {
            Selection = this.Selection,
            Unit = unit
        });
    }
}
