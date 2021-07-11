using UnityEngine;

public static class StatExtensions
{
    public static float CalculateStat(int level, float baseVal, GrowthFactor growth, int traitModifier)
    {
        return baseVal + traitModifier
            + (growth.EarlyMod * Mathf.Sqrt(level))
            + (growth.LinearMod * level)
            + (growth.LateMod * Mathf.Pow(level, 2f));
    }

    public static float Randomize(IntegerLimits baseStats) 
        => Random.Range(baseStats.Min, baseStats.Max + 1);
}
