public struct StrengthStat
{
    /// <summary>
    /// Updates the current values based on the base stats, growth factor, and level
    /// </summary>
    /// <param name="level"></param>
    public void Update(int level)
    {
        Power = StatExtensions.CalculateStat(level, PowerBase, PowerGrowth);
        Brawn = StatExtensions.CalculateStat(level, BrawnBase, BrawnGrowth);
        Body = StatExtensions.CalculateStat(level, BodyBase, BodyGrowth);
    }

    public float PowerBase;
    public float BrawnBase;
    public float BodyBase;

    public float Power { private set; get; }
    public float Brawn { private set; get; }
    public float Body { private set; get; }

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
        get => GrowthFactor.Average(PowerGrowth, BrawnGrowth, BodyGrowth);
    }
}
