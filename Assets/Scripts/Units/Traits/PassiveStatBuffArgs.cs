using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PassiveStatBuffArgs : PassiveEffectArgs
{
    [SerializeField]
    public StatType StatToIncrease;

    [SerializeField]
    public float Amount;
}
