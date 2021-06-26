
[System.Serializable]
public class StatBlock
{
    public StrengthStat Str;
    public ConstitutionStat Con;
    public DexterityStat Dex;
    public IntelligenceStat Int;
    public WisdomStat Wis;

    public StatBlock(int level, GrowthFactorLimits limits)
    {
        RandomizeBaseStats();
        RandomizeGrowthFactors(limits);
        UpdateStats(level);
    }

    public void UpdateStats(int level)
    {
        Str.Update(level);
        Con.Update(level);
        Dex.Update(level);
        Int.Update(level);
        Wis.Update(level);
    }

    public void RandomizeBaseStats()
    {
        Str.RandomizeBaseStats();
        Con.RandomizeBaseStats();
        Dex.RandomizeBaseStats();
        Int.RandomizeBaseStats();
        Wis.RandomizeBaseStats();
    }

    public void RandomizeGrowthFactors(GrowthFactorLimits limits)
    {
        Str.RandomizeGrowthStats(limits);
        Con.RandomizeGrowthStats(limits); 
        Dex.RandomizeGrowthStats(limits);
        Int.RandomizeGrowthStats(limits);
        Wis.RandomizeGrowthStats(limits);
    }
}
