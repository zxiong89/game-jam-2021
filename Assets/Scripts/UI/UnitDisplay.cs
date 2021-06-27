using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI unitName;

    [SerializeField]
    private StatsGroup statsGroup;

    public Unit currentUnit { get; set; }

    public void DisplayUnit(Unit unitToDisplay)
    {
        currentUnit = unitToDisplay;
        unitName.text = unitToDisplay.DisplayName;
        statsGroup.SetStats(currentUnit.Stats);
    }


}
