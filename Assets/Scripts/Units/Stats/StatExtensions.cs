using UnityEngine;

public static class StatExtensions
{
    public static float CalculateStat(int level, float baseVal, GrowthFactor growth)
    {
        return baseVal
            + (growth.EarlyMod * Mathf.Sqrt(level))
            + (growth.LinearMod * level)
            + (growth.LateMod * Mathf.Pow(level, 2f));
    }
}
