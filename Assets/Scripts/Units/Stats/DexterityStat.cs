public struct DexterityStat
{
    public float Speed;
    public float Agility;
    public float Reflexes;

    /// <summary>
    /// Returns the average dexterity value
    /// </summary>
    public float Value
    {
        get => FloatExtensions.Average(Speed + Agility + Reflexes);
    }

    public GrowthFactor SpeedGrowth;
    public GrowthFactor AgilityGrowth;
    public GrowthFactor ReflexesGrowth;

    /// <summary>
    /// Returns the average dexterity growth factor
    /// </summary>
    public GrowthFactor Growth
    {
        get
        {
            return new GrowthFactor()
            {
                EarlyMod = FloatExtensions.Average(SpeedGrowth.EarlyMod, AgilityGrowth.EarlyMod, ReflexesGrowth.EarlyMod),
                LinearMod = FloatExtensions.Average(SpeedGrowth.EarlyMod, AgilityGrowth.EarlyMod, ReflexesGrowth.EarlyMod),
                LateMod = FloatExtensions.Average(SpeedGrowth.EarlyMod, AgilityGrowth.EarlyMod, ReflexesGrowth.EarlyMod)
            };
        }
    }
}
