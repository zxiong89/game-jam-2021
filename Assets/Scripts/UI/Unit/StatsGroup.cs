using UnityEngine;

public class StatsGroup : MonoBehaviour
{
    [SerializeField]
    private LabelValueDisplay[] statDisplays;

    [SerializeField]
    private SubStatsDisplay[] subStatDisplays; 

    public void SetStats(StatBlock stats)
    {
        if (statDisplays == null || statDisplays.Length != 5) return;

        var statsArr = stats.GetStats();
        for (int i = 0; i < statsArr.Length; i++)
        {

            LabelValueDisplay curStatDisplay = statDisplays[i];
            BaseStat curStat = statsArr[i];
            curStatDisplay.SetLabelValue(curStat.Abbreviation, FloatExtensions.ToString(curStat.Value));
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
            setSubStatsDisplayForSingle(subStats.StatDisplay,
                nameof(str.Power), nameof(str.Brawn), nameof(str.Body),
                str.Power, str.Brawn, str.Body);
        }
        else if (stat is ConstitutionStat con)
        {
            setSubStatsDisplayForSingle(subStats.StatDisplay,
                nameof(con.Stamina), nameof(con.Endurance), nameof(con.Vitality),
                con.Stamina, con.Endurance, con.Vitality);
        }
        else if (stat is DexterityStat dex)
        {
            setSubStatsDisplayForSingle(subStats.StatDisplay,
                nameof(dex.Speed), nameof(dex.Agility), nameof(dex.Reflexes),
                dex.Speed, dex.Agility, dex.Reflexes);
        }
        else if (stat is IntelligenceStat intStat)
        {
            setSubStatsDisplayForSingle(subStats.StatDisplay,
                nameof(intStat.Intellect), nameof(intStat.Mind), nameof(intStat.Knowledge),
                intStat.Intellect, intStat.Mind, intStat.Knowledge);
        }
        else if (stat is WisdomStat wis)
        {
            setSubStatsDisplayForSingle(subStats.StatDisplay, 
                nameof(wis.Will), nameof(wis.Sense), nameof(wis.Spirit), 
                wis.Will, wis.Sense, wis.Spirit);
        }
    }

    private void setSubStatsDisplayForSingle(LabelValueDisplay[] displays, 
        string l1, string l2, string l3, 
        float v1, float v2, float v3)
    {
        displays[0].SetLabelValue(l1, FloatExtensions.ToString(v1));
        displays[1].SetLabelValue(l2, FloatExtensions.ToString(v2));
        displays[2].SetLabelValue(l3, FloatExtensions.ToString(v3));
    }
}
