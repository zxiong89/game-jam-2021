
[System.Serializable]
public struct ConstitutionStat
{
    /// <summary>
    /// Updates the current values based on the base stats, growth factor, and level
    /// </summary>
    /// <param name="level"></param>
    public void Update(int level)
    {
        Stamina = StatExtensions.CalculateStat(level, StaminaBase, StaminaGrowth);
        Endurance = StatExtensions.CalculateStat(level, EnduranceBase, EnduranceGrowth);
        Vitality = StatExtensions.CalculateStat(level, VitalityBase, VitalityGrowth);
    }

    public float StaminaBase;
    public float EnduranceBase;
    public float VitalityBase;

    public float Stamina { private set;  get; }
    public float Endurance { private set; get; }
    public float Vitality { private set; get; }

    /// <summary>
    /// Returns the average constitution value
    /// </summary>
    public float Value
    {
        get => FloatExtensions.Average(Stamina + Endurance + Vitality);
    }

    public GrowthFactor StaminaGrowth;
    public GrowthFactor EnduranceGrowth;
    public GrowthFactor VitalityGrowth;

    /// <summary>
    /// Returns the average constitution growth factor
    /// </summary>
    public GrowthFactor Growth
    {
        get => GrowthFactor.Average(StaminaGrowth, EnduranceGrowth, VitalityGrowth);
    }
}
