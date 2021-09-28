using System;
using System.Collections.Generic;
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
        setPrimaryDisplays(stats, scoutingTier, 
            (BaseStat stat) => UnitScouting.ScoutStat(stat.Value, scoutingTier));
    }

    public void SetGrowth(StatBlock stats, int scoutingTier)
    {
        setPrimaryDisplays(stats, scoutingTier,
            (BaseStat stat) =>  UnitScouting.ScoutGrowth(stat, scoutingTier));
    }

    private void setPrimaryDisplays(StatBlock stats, int scoutingTier, Func<BaseStat, string> transform)
    {
        if (statDisplays == null || statDisplays.Length != 5) return;

        var statsArr = stats.GetStats();
        for (int i = 0; i < statsArr.Length; i++)
        {

            LabelValueDisplay curStatDisplay = statDisplays[i];
            BaseStat curStat = statsArr[i];
            curStatDisplay.SetLabelValue(curStat.Abbreviation, transform(curStat));
        }
    }

    public void SetSubStats(StatBlock stats, int scoutingTier)
    {
        if (scoutingTier < 2)
        {
            setSubDisplaysStatus(false);
            return;
        }

        setSubDisplays(stats, (BaseStat stat) => setSubStatFunc(stat, scoutingTier));
    }

    private Dictionary<string, string> setSubStatFunc(BaseStat stat, int scoutingTier)
    {
        var keys = new string[3];
        var values = new float[3];

        if (stat is StrengthStat strStat)
        {
            keys[0] = nameof(StrengthStat.Power);
            values[0] = strStat.Power;

            keys[1] = nameof(StrengthStat.Brawn);
            values[1] = strStat.Brawn;

            keys[2] = nameof(StrengthStat.Body);
            values[2] = strStat.Body;
        }
        else if (stat is ConstitutionStat conStat)
        {
            keys[0] = nameof(ConstitutionStat.Stamina);
            values[0] = conStat.Stamina;

            keys[1] = nameof(ConstitutionStat.Endurance);
            values[1] = conStat.Endurance;

            keys[2] = nameof(ConstitutionStat.Vitality);
            values[2] = conStat.Vitality;
        }
        else if (stat is DexterityStat dexStat)
        {
            keys[0] = nameof(DexterityStat.Speed);
            values[0] = dexStat.Speed;

            keys[1] = nameof(DexterityStat.Agility);
            values[1] = dexStat.Agility;

            keys[2] = nameof(DexterityStat.Reflexes);
            values[2] = dexStat.Reflexes;
        }
        else if (stat is IntelligenceStat intStat)
        {
            keys[0] = nameof(IntelligenceStat.Intellect);
            values[0] = intStat.Intellect;

            keys[1] = nameof(IntelligenceStat.Mind);
            values[1] = intStat.Mind;

            keys[2] = nameof(IntelligenceStat.Knowledge);
            values[2] = intStat.Knowledge;
        }
        else if (stat is WisdomStat wisStat)
        {
            keys[0] = nameof(WisdomStat.Will);
            values[0] = wisStat.Will;

            keys[1] = nameof(WisdomStat.Sense);
            values[1] = wisStat.Sense;

            keys[2] = nameof(WisdomStat.Spirit);
            values[2] = wisStat.Spirit;
        }

        float max = Mathf.Max(values);
        var result = new Dictionary<string, string>();
        for (int i = 0; i < keys.Length; i++)
        {
            result.Add(keys[i], UnitScouting.ScoutSubStat(values[i], max, scoutingTier));
        }

        return result;
    }

    public void SetSubGrowth(StatBlock stats, int scoutingTier)
    {
        if (scoutingTier < 2)
        {
            setSubDisplaysStatus(false);
            return;
        }
        setSubDisplays(stats, (BaseStat stat) => setSubGrowthFunc(stat, scoutingTier));
    }

    private Dictionary<string, string> setSubGrowthFunc(BaseStat stat, int scoutingTier)
    {
        var result = new Dictionary<string, string>();

        if (stat is StrengthStat strStat)
        {
            result.Add(nameof(StrengthStat.Power), UnitScouting.ScoutSubGrowth(strStat.PowerGrowth, scoutingTier));
            result.Add(nameof(StrengthStat.Brawn), UnitScouting.ScoutSubGrowth(strStat.BrawnGrowth, scoutingTier));
            result.Add(nameof(StrengthStat.Body), UnitScouting.ScoutSubGrowth(strStat.BodyGrowth, scoutingTier));
        }
        else if (stat is ConstitutionStat conStat)
        {
            result.Add(nameof(ConstitutionStat.Stamina), UnitScouting.ScoutSubGrowth(conStat.StaminaGrowth, scoutingTier));
            result.Add(nameof(ConstitutionStat.Endurance), UnitScouting.ScoutSubGrowth(conStat.EnduranceGrowth, scoutingTier));
            result.Add(nameof(ConstitutionStat.Vitality), UnitScouting.ScoutSubGrowth(conStat.VitalityGrowth, scoutingTier));
        }
        else if (stat is DexterityStat dexStat)
        {
            result.Add(nameof(DexterityStat.Speed), UnitScouting.ScoutSubGrowth(dexStat.SpeedGrowth, scoutingTier));
            result.Add(nameof(DexterityStat.Agility), UnitScouting.ScoutSubGrowth(dexStat.AgilityGrowth, scoutingTier));
            result.Add(nameof(DexterityStat.Reflexes), UnitScouting.ScoutSubGrowth(dexStat.ReflexesGrowth, scoutingTier));
        }
        else if (stat is IntelligenceStat intStat)
        {
            result.Add(nameof(IntelligenceStat.Intellect), UnitScouting.ScoutSubGrowth(intStat.IntellectGrowth, scoutingTier));
            result.Add(nameof(IntelligenceStat.Mind), UnitScouting.ScoutSubGrowth(intStat.MindGrowth, scoutingTier));
            result.Add(nameof(IntelligenceStat.Knowledge), UnitScouting.ScoutSubGrowth(intStat.KnowledgeGrowth, scoutingTier));
        }
        else if (stat is WisdomStat wisStat)
        {
            result.Add(nameof(WisdomStat.Will), UnitScouting.ScoutSubGrowth(wisStat.WillGrowth, scoutingTier));
            result.Add(nameof(WisdomStat.Sense), UnitScouting.ScoutSubGrowth(wisStat.SenseGrowth, scoutingTier));
            result.Add(nameof(WisdomStat.Spirit), UnitScouting.ScoutSubGrowth(wisStat.SpiritGrowth, scoutingTier));
        }

        return result;
    }

    private void setSubDisplaysStatus(bool activate)
    {
        foreach (var display in subStatDisplays)
        {
            display.SetActive(activate);
        }
    }

    private void setSubDisplays(StatBlock stats, Func<BaseStat, Dictionary<string, string>> transform)
    {
        if (subStatDisplays == null || subStatDisplays.Length != 5) return;

        var statsArr = stats.GetStats();
        for (int i = 0; i < statsArr.Length; i++)
        {
            SubStatsDisplay subStatsDisplay = subStatDisplays[i];
            BaseStat curStat = statsArr[i];
            setSubStatsForSingle(subStatsDisplay, curStat, transform);
        }
    }


    private void setSubStatsForSingle(SubStatsDisplay subStats, BaseStat stat, Func<BaseStat, Dictionary<string, string>> transform)
    {
        if (subStats.StatDisplay.Length != 3) return;

        if (stat is StrengthStat)
        {
            setSubStatsDisplayForSingle(subStats.StatDisplay,
                nameof(StrengthStat.Power), nameof(StrengthStat.Brawn), nameof(StrengthStat.Body),
                transform(stat));
        }
        else if (stat is ConstitutionStat)
        {
            setSubStatsDisplayForSingle(subStats.StatDisplay,
                nameof(ConstitutionStat.Stamina), nameof(ConstitutionStat.Endurance), nameof(ConstitutionStat.Vitality),
                transform(stat));
        }
        else if (stat is DexterityStat)
        {
            setSubStatsDisplayForSingle(subStats.StatDisplay,
                nameof(DexterityStat.Speed), nameof(DexterityStat.Agility), nameof(DexterityStat.Reflexes),
                transform(stat));
        }
        else if (stat is IntelligenceStat)
        {
            setSubStatsDisplayForSingle(subStats.StatDisplay,
                nameof(IntelligenceStat.Intellect), nameof(IntelligenceStat.Mind), nameof(IntelligenceStat.Knowledge),
                transform(stat));
        }
        else if (stat is WisdomStat)
        {
            setSubStatsDisplayForSingle(subStats.StatDisplay, 
                nameof(WisdomStat.Will), nameof(WisdomStat.Sense), nameof(WisdomStat.Spirit),
                transform(stat));
        }
    }

    private void setSubStatsDisplayForSingle(LabelValueDisplay[] displays, 
        string l1, string l2, string l3, Dictionary<string, string> values)
    {
        displays[0].SetLabelValue(l1, values[l1]);
        displays[1].SetLabelValue(l2, values[l2]);
        displays[2].SetLabelValue(l3, values[l3]);
    }
}
