using System.Collections.Generic;

[System.Serializable]
public struct GrowthFactor
{
    public float EarlyMod;
    public float LinearMod;
    public float LateMod;

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
}
