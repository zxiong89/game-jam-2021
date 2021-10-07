using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private IntegerVariable unitScoutingTier;

    private RecruitmentData recruitmentData;

    public void SetResume(RecruitmentData data)
    {
        Unit unitToDisplay = data.UnitForHire;
        int fee = data.Fee;
        nameAndLevels.text = unitToDisplay.DisplayName + " " + GenericStrings.LevelAbbr + unitToDisplay.Level;
        statsGroup.SetStats(unitToDisplay.Stats, unitScoutingTier.Value);

        if (unitScoutingTier.Value > 1)
        {
            var traitNames = new List<string>();
            foreach (var trait in unitToDisplay.Traits)
            {
                traitNames.Add(trait.Name);
            }
            traitsText.text = string.Join(", ", traitNames.ToArray());
        }

        feeText.text = fee.ToString() + " " + GenericStrings.CurrencySymbol;
        recruitmentData = data;
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }

    public void SubmitBid()
    {
        recruitmentOfferEvent.Raise(recruitmentData);
    }
}
