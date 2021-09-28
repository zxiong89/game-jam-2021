using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class BaseStat
{
    public abstract string DisplayName { get; }
    public abstract string Abbreviation { get; }


    protected abstract float[] getStats();

    /// <summary>
    /// Returns the average value
    /// </summary>
    public float Value
    {
        get => FloatExtensions.Average(getStats());
    }

    public abstract void RandomizeBaseStats(IntegerLimits baseStats);
    public abstract void RandomizeGrowthStats(GrowthFactorLimits limits);

    /// <summary>
    /// Updates the current values based on the base stats, growth factor, and level
    /// </summary>
    /// <param name="level"></param>
    /// <paarm name="traitModifiers"></paarm>
    public abstract void Update(int level, int traitModifier);


    private float growthSum = 0f;
    private int growthNum = 0;
    public float OverallGrowthScore
    {
        get => growthSum / growthNum;
    }

    public void AddToOverallGrowthRate(GrowthFactor growth)
    {
        growthSum += growth.Overall;
        growthNum++;
    }
}
