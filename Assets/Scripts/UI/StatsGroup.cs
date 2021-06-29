using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsGroup : MonoBehaviour
{
    [SerializeField]
    private StatsDisplay[] statDisplays;

    public void SetStats(StatBlock stats)
    {
        var statsArr = stats.GetStats();
        for (int i = 0; i < statsArr.Length; i++)
        {

            StatsDisplay curStatDisplay = statDisplays[i];
            BaseStat curStat = statsArr[i];
            curStatDisplay.SetLabel(curStat.Abbreviation);
            curStatDisplay.SetValue(curStat.Value);
        }
    }
}
