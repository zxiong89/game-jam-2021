using UnityEngine;
using UnityEngine.UI;

public class StatsGroup : MonoBehaviour
{
    [SerializeField]
    private LabelValueDisplay[] statDisplays;

    [SerializeField]
    private SubStatsDisplay[] subStatDisplays; 

    public void SetStats(StatBlock stats, int scoutingTier)
    {
        if (statDisplays == null || statDisplays.Length != 5) return;

        var statsArr = stats.GetStats();
        for (int i = 0; i < statsArr.Length; i++)
        {

            LabelValueDisplay curStatDisplay = statDisplays[i];
            BaseStat curStat = statsArr[i];
            curStatDisplay.SetLabelValue(curStat.Abbreviation, UnitScouting.ScoutStat(curStat.Value, scoutingTier));
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }

    public void SetSubStats(StatBlock stats, int scoutingTier)
    {
        if (subStatDisplays == null || subStatDisplays.Length != 5) return;

        if (scoutingTier == 1)
        {
            foreach (var display in subStatDisplays)
            {
                display.SetActive(false);
            }
        }

        var statsArr = stats.GetStats();
        for (int i = 0; i < statsArr.Length; i++)
        {
            SubStatsDisplay subStatsDisplay = subStatDisplays[i];
            BaseStat curStat = statsArr[i];
            setSubStatsForSingle(subStatsDisplay, curStat, scoutingTier);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }

    private void setSubStatsForSingle(SubStatsDisplay subStats, BaseStat stat, int scoutingTier)
    {
        if (subStats.StatDisplay.Length != 3) return;

        if (stat is StrengthStat str)
        {
            setSubStatsDisplayForSingle(subStats.StatDisplay,
                nameof(str.Power), nameof(str.Brawn), nameof(str.Body),
                str.Power, str.Brawn, str.Body, scoutingTier);
        }
        else if (stat is ConstitutionStat con)
        {
            setSubStatsDisplayForSingle(subStats.StatDisplay,
                nameof(con.Stamina), nameof(con.Endurance), nameof(con.Vitality),
                con.Stamina, con.Endurance, con.Vitality, scoutingTier);
        }
        else if (stat is DexterityStat dex)
        {
            setSubStatsDisplayForSingle(subStats.StatDisplay,
                nameof(dex.Speed), nameof(dex.Agility), nameof(dex.Reflexes),
                dex.Speed, dex.Agility, dex.Reflexes, scoutingTier);
        }
        else if (stat is IntelligenceStat intStat)
        {
            setSubStatsDisplayForSingle(subStats.StatDisplay,
                nameof(intStat.Intellect), nameof(intStat.Mind), nameof(intStat.Knowledge),
                intStat.Intellect, intStat.Mind, intStat.Knowledge, scoutingTier);
        }
        else if (stat is WisdomStat wis)
        {
            setSubStatsDisplayForSingle(subStats.StatDisplay, 
                nameof(wis.Will), nameof(wis.Sense), nameof(wis.Spirit), 
                wis.Will, wis.Sense, wis.Spirit, scoutingTier);
        }
    }

    private void setSubStatsDisplayForSingle(LabelValueDisplay[] displays, 
        string l1, string l2, string l3, 
        float v1, float v2, float v3, int scoutingTier)
    {
        float max = Mathf.Max(v1, v2, v3);
        displays[0].SetLabelValue(l1, UnitScouting.ScoutSubStat(v1, max, scoutingTier));
        displays[1].SetLabelValue(l2, UnitScouting.ScoutSubStat(v2, max, scoutingTier));
        displays[2].SetLabelValue(l3, UnitScouting.ScoutSubStat(v3, max, scoutingTier));
    }
}
