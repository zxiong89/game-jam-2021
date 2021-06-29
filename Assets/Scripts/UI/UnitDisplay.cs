using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI unitName;

    [SerializeField]
    private TextMeshProUGUI classDisplay;

    [SerializeField]
    private StatsGroup statsGroup;

    public Unit currentUnit { get; set; }

    public void DisplayUnit(Unit unitToDisplay)
    {
        currentUnit = unitToDisplay;
        unitName.text = unitToDisplay.DisplayName;
        DisplayClass(unitToDisplay.Level.ToString(), "Demon Hunter (Test)");
        statsGroup?.SetStats(currentUnit.Stats);
    }

    public void DisplayClass(string level, string unitClass)
    {
        if (classDisplay == null) return;
        string displayString = "Lv " + level;
        if (unitClass != "") displayString += " " + unitClass;
        classDisplay.text = displayString;
    }

}
