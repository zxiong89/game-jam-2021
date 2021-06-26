using UnityEngine;

[CreateAssetMenu(menuName = "Variables/GrowthLimits")]
public class GrowthFactorLimits : ScriptableObject
{
    [SerializeField]
    private GrowthFactor max;

    [SerializeField]
    private GrowthFactor min;

    public GrowthFactor GetMean() => GrowthFactor.Average(max, min);
}
