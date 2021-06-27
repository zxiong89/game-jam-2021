
[System.Serializable]
public class WisdomStat : BaseStat
{
    #region Fields/Properties

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

    public override void Update(int level)
    {
        Will = StatExtensions.CalculateStat(level, WillBase, WillGrowth);
        Sense = StatExtensions.CalculateStat(level, SenseBase, SenseGrowth);
        Spirit = StatExtensions.CalculateStat(level, SpiritBase, SpiritGrowth);
    }

    public override void RandomizeBaseStats()
    {
        Will = StatExtensions.Randomize();
        Sense = StatExtensions.Randomize();
        Spirit = StatExtensions.Randomize();
    }

    public override void RandomizeGrowthStats(GrowthFactorLimits limits)
    {
        WillGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean);
        SenseGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean);
        SpiritGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean);
    }

    #endregion

    #region StatBase Protected Methods

    protected override float[] getStats() => new[] { Will, Sense, Spirit };

    protected override GrowthFactor[] getGrowthFactors() => new[] { WillGrowth, SenseGrowth, SpiritGrowth };

    #endregion

}
