﻿using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UnitDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI unitName;

    [SerializeField]
    private TextMeshProUGUI classDisplay;

    [SerializeField]
    private TextMeshProUGUI levelDisplay;

    [SerializeField]
    private TextMeshProUGUI levelClassDisplay;

    [SerializeField]
    private TextMeshProUGUI ageDisplay;

    [SerializeField]
    private StatsGroup statsGroup;

    [SerializeField]
    private TraitsGroup traitsGroup;

    public Unit currentUnit { get; set; }

    public void DisplayUnit(Unit unit)
    {
        currentUnit = unit;
        unitName.text = unit.DisplayName;
        if (ageDisplay != null) ageDisplay.text = string.Format("{0} years old",unit.Age.ToString());
        DisplayClass(unit.Level, unit.Class.Data.Name);
        if (statsGroup != null)
        {
            statsGroup?.SetStats(currentUnit.Stats);
            statsGroup?.SetSubStats(currentUnit.Stats);
        }
        if (traitsGroup != null) traitsGroup.DisplayTraits(unit.Traits);
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponentInParent<RectTransform>());
    }

    public void DisplayClass(int level, string unitClass)
    {
        if (classDisplay != null) classDisplay.text = unitClass;

        if (levelClassDisplay == null && levelDisplay == null) return;
        string levelTxt = string.Format("Lv {0}",level);
        if (levelDisplay != null) levelDisplay.text = levelTxt;

        if (levelClassDisplay != null)
        {
            levelClassDisplay.text = string.Format("{0} {1}", levelTxt, unitClass);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponentInParent<RectTransform>());
    }

}