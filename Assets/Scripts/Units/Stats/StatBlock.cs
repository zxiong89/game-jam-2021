
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
    }

    public BaseStat[] GetStats() => new BaseStat[]{ Str, Con, Dex, Int, Wis };
}
