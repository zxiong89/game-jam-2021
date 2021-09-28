
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

    public override void Update(int level, int traitModifier)
    {
        Speed = StatExtensions.CalculateStat(level, SpeedBase, SpeedGrowth, traitModifier);
        Agility = StatExtensions.CalculateStat(level, AgilityBase, AgilityGrowth, traitModifier);
        Reflexes = StatExtensions.CalculateStat(level, ReflexesBase, ReflexesGrowth, traitModifier);
    }

    public override void RandomizeBaseStats(IntegerLimits baseStats)
    {
        Speed = StatExtensions.Randomize(baseStats);
        Agility = StatExtensions.Randomize(baseStats);
        Reflexes = StatExtensions.Randomize(baseStats);
    }

    public override void RandomizeGrowthStats(GrowthFactorLimits limits)
    {
        SpeedGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean, this);
        AgilityGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean, this);
        ReflexesGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean, this);
    }

    #endregion

    #region StatBase Protected Methods

    protected override float[] getStats() => new[] { Speed, Agility, Reflexes };

    #endregion
}
