public struct IntelligenceStat
{
    public float Intellect;
    public float Mind;
    public float Knowledge;

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
        get
        {
            return new GrowthFactor()
            {
                EarlyMod = FloatExtensions.Average(IntellectGrowth.EarlyMod, MindGrowth.EarlyMod, KnowledgeGrowth.EarlyMod),
                LinearMod = FloatExtensions.Average(IntellectGrowth.EarlyMod, MindGrowth.EarlyMod, KnowledgeGrowth.EarlyMod),
                LateMod = FloatExtensions.Average(IntellectGrowth.EarlyMod, MindGrowth.EarlyMod, KnowledgeGrowth.EarlyMod)
            };
        }
    }
}
