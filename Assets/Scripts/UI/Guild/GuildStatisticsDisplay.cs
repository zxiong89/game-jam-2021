using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuildStatisticsDisplay : MonoBehaviour
{
    [SerializeField]
    private LabelValueDisplay goldEarnedDisplay;

    [SerializeField]
    private LabelValueDisplay goldSpentDisplay;

    [SerializeField]
    private LabelValueDisplay totalDefeatedDisplay;

    [SerializeField]
    private LabelValueDisplay totalExploredDisplay;

    private void Start()
    {
        goldEarnedDisplay.SetValue(GuildStatistics.GoldGained);
        goldSpentDisplay.SetValue((GuildStatistics.GoldSpent));
        double defeated = 0d;
        double explored = 0d;

        foreach(var loc in GuildStatistics.WorldResults.Keys)
        {
            var quest = GuildStatistics.WorldResults[loc];
            foreach (var val in quest.Defeated.Values)
            {
                defeated += val;
            }
            foreach (var val in quest.Explored.Values)
            {
                explored += val;
            }
        }
        totalDefeatedDisplay.SetValue(defeated);
        totalExploredDisplay.SetValue(explored);
        LayoutRebuilder.ForceRebuildLayoutImmediate(this.GetComponent<RectTransform>());
    }
}
