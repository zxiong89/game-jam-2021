using UnityEngine;
using TMPro;

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

    public Unit currentUnit { get; set; }

    public void DisplayUnit(Unit unit)
    {
        currentUnit = unit;
        unitName.text = unit.DisplayName;
        if (ageDisplay) ageDisplay.text = string.Format("{0} years old",unit.Age.ToString());
        DisplayClass(unit.Level, unit.Class.Data.Name);
        if (statsGroup != null)
        {
            statsGroup?.SetStats(currentUnit.Stats);
            statsGroup?.SetSubStats(currentUnit.Stats);
        }
    }

    public void DisplayClass(int level, string unitClass)
    {
        if (classDisplay != null) classDisplay.text = unitClass;

        if (levelClassDisplay == null && levelDisplay == null) return;
        string levelTxt = string.Format("Lv {0}",level.ToString());
        if (levelDisplay != null) levelDisplay.text = levelTxt;

        if (levelClassDisplay != null)
        {
            levelClassDisplay.text = string.Format("{0} {1}", level, unitClass);
        }
    }

}
