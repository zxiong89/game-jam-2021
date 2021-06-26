public struct ConstitutionStat
{
    public float Stamina;
    public float Endurance;
    public float Vitality;

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
        get
        {
            return new GrowthFactor()
            {
                EarlyMod = FloatExtensions.Average(StaminaGrowth.EarlyMod, EnduranceGrowth.EarlyMod, VitalityGrowth.EarlyMod),
                LinearMod = FloatExtensions.Average(StaminaGrowth.EarlyMod, EnduranceGrowth.EarlyMod, VitalityGrowth.EarlyMod),
                LateMod = FloatExtensions.Average(StaminaGrowth.EarlyMod, EnduranceGrowth.EarlyMod, VitalityGrowth.EarlyMod)
            };
        }
    }
}
