using System.Collections.Generic;

[System.Serializable]
public struct GrowthFactor
{
    public float EarlyMod;
    public float LinearMod;
    public float LateMod;

    /// <summary>
    /// Returns the overall rating of the growth after being normalized between [0, 1] based on its generated limits
    /// </summary>
    public float Overall;

    /// <summary>
    /// Returns the average of the three growth factors. This value has not been standardized.
    /// </summary>
    public static GrowthFactor Average(params GrowthFactor[] args)
    {
        List<float> early = new List<float>();
        List<float> linear = new List<float>();
        List<float> late = new List<float>();

        foreach (var f in args) 
        {
            early.Add(f.EarlyMod);
            linear.Add(f.LinearMod);
            late.Add(f.LateMod);
        }

        return new GrowthFactor()
        {
            EarlyMod = FloatExtensions.Average(early.ToArray()),
            LinearMod = FloatExtensions.Average(linear.ToArray()),
            LateMod = FloatExtensions.Average(late.ToArray())
        };
    }

    public static GrowthFactor Randomize(GrowthFactor min, GrowthFactor max, GrowthFactor mean, BaseStat stat)
    {
        var factor = new GrowthFactor
        {
            EarlyMod = FloatExtensions.Randomize(min.EarlyMod, max.EarlyMod, mean.EarlyMod),
            LinearMod = FloatExtensions.Randomize(min.LinearMod, max.LinearMod, mean.LinearMod),
            LateMod = FloatExtensions.Randomize(min.LateMod, max.LateMod, mean.LateMod),
        };
        factor.Overall = NormalizeGrowthFactor(factor, min, max);
        stat.AddToOverallGrowthRate(factor);

        return factor;
    }

    /// <summary>
    /// Find the overall growth factor based on the mean limits. 
    /// This value will normalized between [0, 1]
    /// </summary>
    /// <param name="growth"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns>Overall growth factor between value [0, 1]</returns>
    public static float NormalizeGrowthFactor(GrowthFactor growth, GrowthFactor min, GrowthFactor max)
    {
        var growthSum = FloatExtensions.Normalize(growth.EarlyMod, min.EarlyMod, max.EarlyMod);
        growthSum += FloatExtensions.Normalize(growth.LinearMod, min.LinearMod, max.LinearMod);
        growthSum += FloatExtensions.Normalize(growth.LateMod, min.LateMod, max.LateMod);
        return growthSum / 3;
    }
}
