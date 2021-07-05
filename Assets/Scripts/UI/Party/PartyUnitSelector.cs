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

    public bool IsFrontline;

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

        PartyStats? baseline = null;
        if (currentUnit != null)
        {
            baseline = currentUnit.CalcContribution(IsFrontline);
            instantiateUnitSelector(currentUnit, baseline, true);
        }

        foreach (Unit u in guild.Roster)
        {
            if (CurrentParty.Party.Contains(u)) continue;
            instantiateUnitSelector(u, baseline, false);
        }
    }

    private void instantiateUnitSelector(Unit unit, PartyStats? baseline, bool isOn = false)
    {
        if (unit == null) return;
        var toggle = GameObject.Instantiate<Toggle>(toggleSummaryPrefab, contentContainer);
        toggle.isOn = isOn;
        toggle.group = toggleGroup;
        
        var partySummaryDisplay = toggle.GetComponent<PartyUnitSelectorSummary>();
        if (partySummaryDisplay != null)
        {
            partySummaryDisplay.IsFrontline = IsFrontline;
            partySummaryDisplay.Baseline = baseline;
        }

        var unitDisplay = toggle.GetComponent<UnitDisplay>();
        if (unitDisplay != null) unitDisplay.DisplayUnit(unit);
    }

    public Unit GetSelectedUnit()
    {
        var toggle = ToggleExtensions.FindSelectedToggle(toggleGroup);
        if (toggle == null) return null;

        var unitDisplay = toggle.GetComponent<UnitDisplay>();
        return unitDisplay?.currentUnit;
    }
}
