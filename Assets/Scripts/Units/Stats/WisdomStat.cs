public struct WisdomStat
{
    /// <summary>
    /// Updates the current values based on the base stats, growth factor, and level
    /// </summary>
    /// <param name="level"></param>
    public void Update(int level)
    {
        Will = StatExtensions.CalculateStat(level, WillBase, WillGrowth);
        Sense = StatExtensions.CalculateStat(level, SenseBase, SenseGrowth);
        Spirit = StatExtensions.CalculateStat(level, SpiritBase, SpiritGrowth);
    }

    public float WillBase;
    public float SenseBase;
    public float SpiritBase;

    public float Will { private set; get; }
    public float Sense { private set; get; }
    public float Spirit { private set; get; }

    public float Value
    {
        get => FloatExtensions.Average(Will, Sense, Spirit);
    }

    public GrowthFactor WillGrowth;
    public GrowthFactor SenseGrowth;
    public GrowthFactor SpiritGrowth;

    public GrowthFactor Growth
    {
        get => GrowthFactor.AverageGrowthFactor(WillGrowth, SenseGrowth, SpiritGrowth);
    }
}
