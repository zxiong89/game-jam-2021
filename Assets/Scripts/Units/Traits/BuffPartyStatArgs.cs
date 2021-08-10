using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffPartyStatArgs : PartyTraitEffectArgs
{
    [SerializeField]
    private StatType statToIncrease;

    public StatType StatToIncrease
    {
        get { return statToIncrease; }
    }


    [SerializeField]
    private float amount;

    public float Amount
    {
        get { return amount; }
    }

}
