using UnityEngine;

[CreateAssetMenu(menuName = "Variables/GrowthLimits")]
public class GrowthFactorLimits : ScriptableObject
{
    public GrowthFactor Min;
    public GrowthFactor Mean;
    public GrowthFactor Max;
}
