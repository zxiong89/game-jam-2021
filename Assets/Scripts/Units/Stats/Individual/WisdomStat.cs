
[System.Serializable]
public class WisdomStat : BaseStat
{
    #region Fields/Properties
    public override string DisplayName => "Wisdom";
    public override string Abbreviation => "Wis";

    public float WillBase;
    public float SenseBase;
    public float SpiritBase;

    public float Will { private set; get; }
    public float Sense { private set; get; }
    public float Spirit { private set; get; }

    public GrowthFactor WillGrowth;
    public GrowthFactor SenseGrowth;
    public GrowthFactor SpiritGrowth;

    #endregion

    #region Stat Base Public Methods

    public override void Update(int level, int traitModifier)
    {
        Will = StatExtensions.CalculateStat(level, WillBase, WillGrowth, traitModifier);
        Sense = StatExtensions.CalculateStat(level, SenseBase, SenseGrowth, traitModifier);
        Spirit = StatExtensions.CalculateStat(level, SpiritBase, SpiritGrowth, traitModifier);
    }

    public override void RandomizeBaseStats(IntegerLimits baseStats)
    {
        Will = StatExtensions.Randomize(baseStats);
        Sense = StatExtensions.Randomize(baseStats);
        Spirit = StatExtensions.Randomize(baseStats);
    }

    public override void RandomizeGrowthStats(GrowthFactorLimits limits)
    {
        WillGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean, this);
        SenseGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean, this);
        SpiritGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean, this);
    }

    #endregion

    #region StatBase Protected Methods

    protected override float[] getStats() => new[] { Will, Sense, Spirit };

    protected override GrowthFactor[] getGrowthFactors() => new[] { WillGrowth, SenseGrowth, SpiritGrowth };

    #endregion

}
