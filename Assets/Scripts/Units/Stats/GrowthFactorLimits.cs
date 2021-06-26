using UnityEngine;

[CreateAssetMenu(menuName = "Variables/GrowthLimits")]
public class GrowthFactorLimits : ScriptableObject
{
    public GrowthFactor Min;

    public GrowthFactor Max;

    public GrowthFactor GetMean() => GrowthFactor.Average(Min, Max);
}
