
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

    public BaseStat GetStat(StatType type)
    {
        switch (type) 
        {
            case StatType.Str:
                return Str;
            case StatType.Dex:
                return Dex;
            case StatType.Con:
                return Con;
            case StatType.Int:
                return Int;
            case StatType.Wis:
            default:
                return Wis;
        }
    }

    public void ResetPartyMods()
    {
        foreach(var stat in GetStats())
        {
            stat.partyModifier = 0;
        }
    }
}
