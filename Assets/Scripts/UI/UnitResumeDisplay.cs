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

    [SerializeField]
    private RecruitmentEvent recruitmentOfferEvent;

    private RecruitmentData recruitmentData;

    public void SetResume(RecruitmentData data)
    {
        Unit unitToDisplay = data.UnitForHire;
        int fee = data.Fee;
        nameAndLevels.text = unitToDisplay.DisplayName + " " + GenericStrings.LevelAbbr + unitToDisplay.Level;
        statsGroup.SetStats(unitToDisplay.Stats);
        traitsText.text = "Vigilant, Brawny, Sluggish";
        feeText.text = fee.ToString() + " " + GenericStrings.CurrencySymbol;
        recruitmentData = data;
    }

    public void SubmitBid()
    {
        recruitmentOfferEvent.Raise(recruitmentData);
    }
}
