
[System.Serializable]
public class StrengthStat : BaseStat
{
    #region Fields/Properties
    public override string DisplayName => "Strength";
    public override string Abbreviation => "Str";

    public float PowerBase;
    public float BrawnBase;
    public float BodyBase;

    public float Power { private set; get; }
    public float Brawn { private set; get; }
    public float Body { private set; get; }

    public GrowthFactor PowerGrowth;
    public GrowthFactor BrawnGrowth;
    public GrowthFactor BodyGrowth;

    #endregion

    #region Stat Base Public Methods

    public override void Update(int level, int traitModifier)
    {
        Power = StatExtensions.CalculateStat(level, PowerBase, PowerGrowth, traitModifier);
        Brawn = StatExtensions.CalculateStat(level, BrawnBase, BrawnGrowth, traitModifier);
        Body = StatExtensions.CalculateStat(level, BodyBase, BodyGrowth, traitModifier);
    }

    public override void RandomizeBaseStats(IntegerLimits baseStats)
    {
        Power = StatExtensions.Randomize(baseStats);
        Brawn = StatExtensions.Randomize(baseStats);
        Body = StatExtensions.Randomize(baseStats);
    }

    public override void RandomizeGrowthStats(GrowthFactorLimits limits)
    {
        PowerGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean, this);
        BrawnGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean, this);
        BodyGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean, this);
    }

    #endregion

    #region StatBase Protected Methods

    protected override float[] getStats() => new[] { Power, Brawn, Body };

    #endregion
}
