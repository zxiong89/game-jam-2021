
[System.Serializable]
public struct IntelligenceStat
{
    /// <summary>
    /// Updates the current values based on the base stats, growth factor, and level
    /// </summary>
    /// <param name="level"></param>
    public void Update(int level)
    {
        Intellect = StatExtensions.CalculateStat(level, IntellectBase, IntellectGrowth);
        Mind = StatExtensions.CalculateStat(level, MindBase, MindGrowth);
        Knowledge = StatExtensions.CalculateStat(level, KnowledgeBase, KnowledgeGrowth);
    }

    public float IntellectBase;
    public float MindBase;
    public float KnowledgeBase;

    public float Intellect { private set; get; }
    public float Mind { private set; get; }
    public float Knowledge { private set; get; }

    /// <summary>
    /// Returns the average intelligence value
    /// </summary>
    public float Value
    {
        get => FloatExtensions.Average(Intellect + Mind + Knowledge);
    }

    public GrowthFactor IntellectGrowth;
    public GrowthFactor MindGrowth;
    public GrowthFactor KnowledgeGrowth;

    /// <summary>
    /// Returns the average intelligence growth factor
    /// </summary>
    public GrowthFactor Growth
    {
        get => GrowthFactor.Average(IntellectGrowth, MindGrowth, KnowledgeGrowth);
    }
}
