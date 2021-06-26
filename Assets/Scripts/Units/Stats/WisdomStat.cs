public struct WisdomStat
{
    public float Will;
    public float Sense;
    public float Spirit;

    /// <summary>
    /// Returns the average wisdom value
    /// </summary>
    public float Value
    {
        get => FloatExtensions.Average(Will, Sense, Spirit);
    }

    public GrowthFactor WillGrowth;
    public GrowthFactor SenseGrowth;
    public GrowthFactor SpiritGrowth;

    /// <summary>
    /// Returns the average wisdom growth factor
    /// </summary>
    public GrowthFactor Growth
    {
        get
        {
            return new GrowthFactor()
            {
                EarlyMod = FloatExtensions.Average(WillGrowth.EarlyMod, SenseGrowth.EarlyMod, SpiritGrowth.EarlyMod),
                LinearMod = FloatExtensions.Average(WillGrowth.EarlyMod, SenseGrowth.EarlyMod, SpiritGrowth.EarlyMod),
                LateMod = FloatExtensions.Average(WillGrowth.EarlyMod, SenseGrowth.EarlyMod, SpiritGrowth.EarlyMod)
            };
        }
    }
}
