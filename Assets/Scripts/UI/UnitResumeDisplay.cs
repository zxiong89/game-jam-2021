using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitResumeDisplay : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sprite;

    [SerializeField]
    private TextMeshProUGUI nameAndLevels;

    [SerializeField]
    private StatsGroup statsGroup;

    [SerializeField]
    private TextMeshProUGUI traitsText;

    [SerializeField]
    private TextMeshProUGUI feeText;

    public void SetResume(Unit unitToDisplay, int fee)
    {
        nameAndLevels.text = unitToDisplay.DisplayName + " " + GenericStrings.LevelAbbr + unitToDisplay.Level;
        statsGroup.SetStats(unitToDisplay.Stats);
        traitsText.text = "Vigilant, Brawny, Sluggish";
        feeText.text = fee.ToString() + " " + GenericStrings.CurrencySymbol;

    }
}
