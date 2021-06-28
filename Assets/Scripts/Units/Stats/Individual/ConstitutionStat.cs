
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

    public override void Update(int level)
    {
        Stamina = StatExtensions.CalculateStat(level, StaminaBase, StaminaGrowth);
        Endurance = StatExtensions.CalculateStat(level, EnduranceBase, EnduranceGrowth);
        Vitality = StatExtensions.CalculateStat(level, VitalityBase, VitalityGrowth);
    }

    public override void RandomizeBaseStats()
    {
        Stamina = StatExtensions.Randomize();
        Endurance = StatExtensions.Randomize();
        Vitality = StatExtensions.Randomize();
    }

    public override void RandomizeGrowthStats(GrowthFactorLimits limits)
    {
        StaminaGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean);
        EnduranceGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean);
        VitalityGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean);
    }

    #endregion

    #region StatBase Protected Methods

    protected override float[] getStats() => new[] { Stamina, Endurance, Vitality };

    protected override GrowthFactor[] getGrowthFactors() => new[] { StaminaGrowth, EnduranceGrowth, VitalityGrowth };

    #endregion
}
