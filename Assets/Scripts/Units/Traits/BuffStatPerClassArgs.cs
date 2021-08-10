using UnityEngine;

[System.Serializable]
public class BuffStatPerClassArgs : PartyTraitEffectArgs
{
    [SerializeField]
    private StatType classPrimaryStat;

    public StatType ClassPrimaryStat
    {
        get { return classPrimaryStat; }
    }


    [SerializeField]
    private StatType statToIncrease;
    public StatType StatToIncrease
    {
        get { return statToIncrease; }
    }

    [SerializeField]
    private float increaseAmount;

    public float IncreaseAmount
    {
        get { return increaseAmount; }
    }
}
