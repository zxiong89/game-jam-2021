
[System.Serializable]
public struct DexterityStat
{
    /// <summary>
    /// Updates the current values based on the base stats, growth factor, and level
    /// </summary>
    /// <param name="level"></param>
    public void Update(int level)
    {
        Speed = StatExtensions.CalculateStat(level, SpeedBase, SpeedGrowth);
        Agility = StatExtensions.CalculateStat(level, AgilityBase, AgilityGrowth);
        Reflexes = StatExtensions.CalculateStat(level, ReflexesBase, ReflexesGrowth);
    }

    public float SpeedBase;
    public float AgilityBase;
    public float ReflexesBase;

    public float Speed { private set; get; }
    public float Agility { private set; get; }
    public float Reflexes { private set; get; }

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
        get => GrowthFactor.Average(SpeedGrowth, AgilityGrowth, ReflexesGrowth);
    }
}
