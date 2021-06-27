using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractStatBase
{
    protected abstract float[] getStats();
    /// <summary>
    /// Returns the average value
    /// </summary>
    public float Value
    {
        get => FloatExtensions.Average(getStats());
    }

    protected abstract GrowthFactor[] getGrowthFactors();
    /// <summary>
    /// Returns the average intelligence growth factor
    /// </summary>
    public GrowthFactor Growth
    {
        get => GrowthFactor.Average(getGrowthFactors());
    }

    public abstract void RandomizeBaseStats();
    public abstract void RandomizeGrowthStats(GrowthFactorLimits limits);

    /// <summary>
    /// Updates the current values based on the base stats, growth factor, and level
    /// </summary>
    /// <param name="level"></param>
    public abstract void Update(int level);

}
