using UnityEngine;

[CreateAssetMenu(menuName = "Variables/GrowthLimits")]
[System.Serializable]
public class GrowthFactorLimits : ScriptableObject
{
    public GrowthFactor Min;
    public GrowthFactor Mean;
    public GrowthFactor Max;
}
