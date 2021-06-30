using UnityEngine;

public class StatsGroup : MonoBehaviour
{
    [SerializeField]
    private StatsDisplay[] statDisplays;

    [SerializeField]
    private SubStatsDisplay[] subStatDisplays; 

    public void SetStats(StatBlock stats)
    {
        if (statDisplays == null || statDisplays.Length != 5) return;

        var statsArr = stats.GetStats();
        for (int i = 0; i < statsArr.Length; i++)
        {

            StatsDisplay curStatDisplay = statDisplays[i];
            BaseStat curStat = statsArr[i];
            curStatDisplay.SetLabelValue(curStat.Abbreviation, curStat.Value);
        }
    }

    public void SetSubStats(StatBlock stats)
    {
        if (subStatDisplays == null || subStatDisplays.Length != 5) return;

        var statsArr = stats.GetStats();
        for (int i = 0; i < statsArr.Length; i++)
        {
            SubStatsDisplay subStatsDisplay = subStatDisplays[i];
            BaseStat curStat = statsArr[i];
            setSubStatsForSingle(subStatsDisplay, curStat);
        }
    }

    private void setSubStatsForSingle(SubStatsDisplay subStats, BaseStat stat)
    {
        if (subStats.StatDisplay.Length != 3) return;

        if (stat is StrengthStat str)
        {
            subStats.StatDisplay[0].SetLabelValue(nameof(str.Power), str.Power);
            subStats.StatDisplay[1].SetLabelValue(nameof(str.Brawn), str.Brawn);
            subStats.StatDisplay[2].SetLabelValue(nameof(str.Body), str.Body);
        }
        else if (stat is ConstitutionStat con)
        {
            subStats.StatDisplay[0].SetLabelValue(nameof(con.Stamina), con.Stamina);
            subStats.StatDisplay[1].SetLabelValue(nameof(con.Endurance), con.Endurance);
            subStats.StatDisplay[2].SetLabelValue(nameof(con.Vitality), con.Vitality);
        }
        else if (stat is DexterityStat dex)
        {
            subStats.StatDisplay[0].SetLabelValue(nameof(dex.Speed), dex.Speed);
            subStats.StatDisplay[1].SetLabelValue(nameof(dex.Agility), dex.Agility);
            subStats.StatDisplay[2].SetLabelValue(nameof(dex.Reflexes), dex.Reflexes);
        }
        else if (stat is IntelligenceStat intStat)
        {
            subStats.StatDisplay[0].SetLabelValue(nameof(intStat.Intellect), intStat.Intellect);
            subStats.StatDisplay[1].SetLabelValue(nameof(intStat.Mind), intStat.Mind);
            subStats.StatDisplay[2].SetLabelValue(nameof(intStat.Knowledge), intStat.Knowledge);
        }
        else if (stat is WisdomStat wis)
        {
            subStats.StatDisplay[0].SetLabelValue(nameof(wis.Will), wis.Will);
            subStats.StatDisplay[1].SetLabelValue(nameof(wis.Sense), wis.Sense);
            subStats.StatDisplay[2].SetLabelValue(nameof(wis.Spirit), wis.Spirit);
        }
    }
}
