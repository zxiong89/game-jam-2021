
[System.Serializable]
public class IntelligenceStat : AbstractStatBase
{
    #region Fields/Properties
    public override string DisplayName => "Intelligence";
    public override string Abbreviation => "Int";

    public float IntellectBase;
    public float MindBase;
    public float KnowledgeBase;

    public float Intellect { private set; get; }
    public float Mind { private set; get; }
    public float Knowledge { private set; get; }

    public GrowthFactor IntellectGrowth;
    public GrowthFactor MindGrowth;
    public GrowthFactor KnowledgeGrowth;

    #endregion

    #region Stat Base Public Methods

    public override void Update(int level)
    {
        Intellect = StatExtensions.CalculateStat(level, IntellectBase, IntellectGrowth);
        Mind = StatExtensions.CalculateStat(level, MindBase, MindGrowth);
        Knowledge = StatExtensions.CalculateStat(level, KnowledgeBase, KnowledgeGrowth);
    }

    public override void RandomizeBaseStats()
    {
        Intellect = StatExtensions.Randomize();
        Mind = StatExtensions.Randomize();
        Knowledge = StatExtensions.Randomize();
    }

    public override void RandomizeGrowthStats(GrowthFactorLimits limits)
    {
        IntellectGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean);
        MindGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean);
        KnowledgeGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean);
    }

    #endregion

    #region StatBase Protected Methods

    protected override float[] getStats() => new[] { Intellect, Mind, Knowledge };

    protected override GrowthFactor[] getGrowthFactors() => new[] { IntellectGrowth, MindGrowth, KnowledgeGrowth };

    #endregion
}
