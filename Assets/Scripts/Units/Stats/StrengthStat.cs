public struct StrengthStat
{
    public float Power;
    public float Brawn;
    public float Body;

    /// <summary>
    /// Returns the average strength value
    /// </summary>
    public float Value
    {
        get => FloatExtensions.Average(Power + Brawn + Body);
    }

    public GrowthFactor PowerGrowth;
    public GrowthFactor BrawnGrowth;
    public GrowthFactor BodyGrowth;

    /// <summary>
    /// Returns the average strength growth factor
    /// </summary>
    public GrowthFactor Growth
    {
        get
        {
            return new GrowthFactor()
            {
                EarlyMod = FloatExtensions.Average(PowerGrowth.EarlyMod, BrawnGrowth.EarlyMod, BodyGrowth.EarlyMod),
                LinearMod = FloatExtensions.Average(PowerGrowth.EarlyMod, BrawnGrowth.EarlyMod, BodyGrowth.EarlyMod),
                LateMod = FloatExtensions.Average(PowerGrowth.EarlyMod, BrawnGrowth.EarlyMod, BodyGrowth.EarlyMod)
            };
        }
    }
}
