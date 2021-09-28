
using System;
using UnityEngine;

[System.Serializable]
public class StatBlock
{
    public StrengthStat Str = new StrengthStat();
    public ConstitutionStat Con = new ConstitutionStat();
    public DexterityStat Dex = new DexterityStat();
    public IntelligenceStat Int = new IntelligenceStat();
    public WisdomStat Wis = new WisdomStat();

    public StatBlock(int level, IntegerLimits baseStats, GrowthFactorLimits limits)
    {
        RandomizeBaseStats(baseStats);
        RandomizeGrowthFactors(limits);
        UpdateStats(level, new int[] { 0, 0, 0, 0, 0 });
    }

    public void UpdateStats(int level, int[] traitModifiers)
    {
        Str.Update(level, traitModifiers[0]);
        Con.Update(level, traitModifiers[1]);
        Dex.Update(level, traitModifiers[2]);
        Int.Update(level, traitModifiers[3]);
        Wis.Update(level, traitModifiers[4]);
    }

    public void RandomizeBaseStats(IntegerLimits baseStats)
    {
        Str.RandomizeBaseStats(baseStats);
        Con.RandomizeBaseStats(baseStats);
        Dex.RandomizeBaseStats(baseStats);
        Int.RandomizeBaseStats(baseStats);
        Wis.RandomizeBaseStats(baseStats);
    }

    public void RandomizeGrowthFactors(GrowthFactorLimits limits)
    {
        Str.RandomizeGrowthStats(limits);
        Con.RandomizeGrowthStats(limits);
        Dex.RandomizeGrowthStats(limits);
        Int.RandomizeGrowthStats(limits);
        Wis.RandomizeGrowthStats(limits);

        var stats = GetStats();
        overallGrowthScore = 0f;
        foreach (var s in stats)
        {
            overallGrowthScore += s.OverallGrowthScore;
        }
        overallGrowthScore /= stats.Length;
    }

    public BaseStat[] GetStats() => new BaseStat[]{ Str, Con, Dex, Int, Wis };

    private float overallGrowthScore = 0f;
    public float OverallGrowthScore
    {
        get => overallGrowthScore;
    }
}
