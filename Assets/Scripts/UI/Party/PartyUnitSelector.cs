using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyUnitSelector : MonoBehaviour
{
    [Header("Display")]

    [SerializeField]
    private Toggle toggleSummaryPrefab;

    [SerializeField]
    private Transform contentContainer;

    [Header("Data")]

    public PartyData CurrentParty;

    [SerializeField]
    private Guild guild;
    
    private ToggleGroup toggleGroup;

    private void Awake()
    {
        toggleGroup = contentContainer.gameObject.GetComponent<ToggleGroup>();
    }

    public void PopulateRoster(Unit currentUnit)
    {
        if (guild == null) return;
        if (CurrentParty == null && CurrentParty.Party == null) return;

        instantiateUnitSelector(currentUnit, true);

        //foreach (Unit u in CurrentParty.Party.FrontLine)
        //{
        //    if (u == Selection?.Unit) return;
        //    instantiateUnitSelector(Selection.Unit, true);
        //}

        //foreach (Unit u in CurrentParty.Party.BackLine)
        //{
        //    if (u == Selection?.Unit) return;
        //    instantiateUnitSelector(Selection.Unit, true);
        //}

        foreach (Unit u in guild.Roster)
        {
            if (CurrentParty.Party.Contains(u)) continue;
            instantiateUnitSelector(u, false);
        }
    }

    private void instantiateUnitSelector(Unit unit, bool isOn = false)
    {
        if (unit == null) return;
        var toggle = GameObject.Instantiate<Toggle>(toggleSummaryPrefab, contentContainer);
        toggle.isOn = isOn;
        toggle.group = toggleGroup;
        var unitDisplay = toggle.GetComponent<UnitDisplay>();
        if (unitDisplay == null) return;
        unitDisplay.DisplayUnit(unit);
    }

    public Unit GetSelectedUnit()
    {
        var toggle = ToggleExtensions.FindSelectedToggle(toggleGroup);
        if (toggle == null) return null;

        var unitDisplay = toggle.GetComponent<UnitDisplay>();
        return unitDisplay?.currentUnit;
    }
}
