
[System.Serializable]
public class ConstitutionStat : BaseStat
{
    #region Fields/Properties

    public override string DisplayName => "Constitution";
    public override string Abbreviation => "Con";

    public float StaminaBase;
    public float EnduranceBase;
    public float VitalityBase;

    public float Stamina { private set; get; }
    public float Endurance { private set; get; }
    public float Vitality { private set; get; }

    public GrowthFactor StaminaGrowth;
    public GrowthFactor EnduranceGrowth;
    public GrowthFactor VitalityGrowth;

    #endregion

    #region Stat Base Public Methods

    public override void Update(int level, int traitModifier)
    {
        Stamina = StatExtensions.CalculateStat(level, StaminaBase, StaminaGrowth, traitModifier);
        Endurance = StatExtensions.CalculateStat(level, EnduranceBase, EnduranceGrowth, traitModifier);
        Vitality = StatExtensions.CalculateStat(level, VitalityBase, VitalityGrowth, traitModifier);
    }

    public override void RandomizeBaseStats(IntegerLimits baseStats)
    {
        Stamina = StatExtensions.Randomize(baseStats);
        Endurance = StatExtensions.Randomize(baseStats);
        Vitality = StatExtensions.Randomize(baseStats);
    }

    public override void RandomizeGrowthStats(GrowthFactorLimits limits)
    {
        StaminaGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean, this);
        EnduranceGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean, this);
        VitalityGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean, this);
    }

    #endregion

    #region StatBase Protected Methods

    protected override float[] getStats() => new[] { Stamina, Endurance, Vitality };

    #endregion
}
