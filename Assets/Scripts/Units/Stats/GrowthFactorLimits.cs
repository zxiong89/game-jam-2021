using UnityEngine;

[CreateAssetMenu(menuName = "Variables/GrowthLimits")]
public class GrowthFactorLimits : ScriptableObject
{
    [SerializeField]
    private GrowthFactor min;

    [SerializeField]
    private GrowthFactor max;

    public GrowthFactor GetMean() => GrowthFactor.Average(min, max);
}
