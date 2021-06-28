
[System.Serializable]
public class DexterityStat : BaseStat
{
    #region Fields/Properties
    public override string DisplayName => "Dexterity";
    public override string Abbreviation => "Dex";

    public float SpeedBase;
    public float AgilityBase;
    public float ReflexesBase;

    public float Speed { private set; get; }
    public float Agility { private set; get; }
    public float Reflexes { private set; get; }

    public GrowthFactor SpeedGrowth;
    public GrowthFactor AgilityGrowth;
    public GrowthFactor ReflexesGrowth;

    #endregion

    #region Stat Base Public Methods

    public override void Update(int level)
    {
        Speed = StatExtensions.CalculateStat(level, SpeedBase, SpeedGrowth);
        Agility = StatExtensions.CalculateStat(level, AgilityBase, AgilityGrowth);
        Reflexes = StatExtensions.CalculateStat(level, ReflexesBase, ReflexesGrowth);
    }

    public override void RandomizeBaseStats()
    {
        Speed = StatExtensions.Randomize();
        Agility = StatExtensions.Randomize();
        Reflexes = StatExtensions.Randomize();
    }

    public override void RandomizeGrowthStats(GrowthFactorLimits limits)
    {
        SpeedGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean);
        AgilityGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean);
        ReflexesGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean);
    }

    #endregion

    #region StatBase Protected Methods

    protected override float[] getStats() => new[] { Speed, Agility, Reflexes };

    protected override GrowthFactor[] getGrowthFactors() => new[] { SpeedGrowth, AgilityGrowth, ReflexesGrowth };

    #endregion
}
