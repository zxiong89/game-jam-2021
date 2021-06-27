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

    public static float Randomize(int min = 10, int max = 30) => Random.Range(min, max);
}
