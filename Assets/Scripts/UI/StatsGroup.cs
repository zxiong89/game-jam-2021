using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsGroup : MonoBehaviour
{
    [SerializeField]
    private StatsDisplay[] statDisplays;

    public void SetStats(AbstractStatBase[] stats)
    {
        if(stats.Length != 5)
        {
            throw new System.Exception("There must be 5 stats");
        }
        for (int i = 0; i < stats.Length; i++)
        {
            StatsDisplay curStatDisplay = statDisplays[i];
            AbstractStatBase curStat = stats[i];
            curStatDisplay.SetLabel(curStat.Abbreviation);
            curStatDisplay.SetValue(curStat.Value.ToString());
        }
    }
}
