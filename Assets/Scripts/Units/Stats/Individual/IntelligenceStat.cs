
[System.Serializable]
public class IntelligenceStat : BaseStat
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

    public override void Update(int level, int traitModifier)
    {
        Intellect = StatExtensions.CalculateStat(level, IntellectBase, IntellectGrowth, traitModifier);
        Mind = StatExtensions.CalculateStat(level, MindBase, MindGrowth, traitModifier);
        Knowledge = StatExtensions.CalculateStat(level, KnowledgeBase, KnowledgeGrowth, traitModifier);
    }

    public override void RandomizeBaseStats(IntegerLimits baseStats)
    {
        Intellect = StatExtensions.Randomize(baseStats);
        Mind = StatExtensions.Randomize(baseStats);
        Knowledge = StatExtensions.Randomize(baseStats);
    }

    public override void RandomizeGrowthStats(GrowthFactorLimits limits)
    {
        IntellectGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean, this);
        MindGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean, this);
        KnowledgeGrowth = GrowthFactor.Randomize(limits.Min, limits.Max, limits.Mean, this);
    }

    #endregion

    #region StatBase Protected Methods

    protected override float[] getStats() => new[] { Intellect, Mind, Knowledge };

    protected override GrowthFactor[] getGrowthFactors() => new[] { IntellectGrowth, MindGrowth, KnowledgeGrowth };

    #endregion
}
