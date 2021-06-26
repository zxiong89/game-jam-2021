public struct GrowthFactor
{
    private const float STD_EARLY_MOD = 10f;
    private const float STD_LINEAR_MOD = 1.5f;
    private const float STD_LATE_MOD = 0.02f;

    public float EarlyMod;
    public float LinearMod;
    public float LateMod;

    public static GrowthFactor AverageGrowthFactor(GrowthFactor g1, GrowthFactor g2, GrowthFactor g3)
    {
        return new GrowthFactor()
        {
            EarlyMod = FloatExtensions.Average(g1.EarlyMod, g2.EarlyMod, g3.EarlyMod) / STD_EARLY_MOD,
            LinearMod = FloatExtensions.Average(g1.LinearMod, g2.LinearMod, g3.LinearMod) / STD_LINEAR_MOD,
            LateMod = FloatExtensions.Average(g1.LateMod, g2.LateMod, g3.LateMod) / STD_LATE_MOD
        };
    }
}
