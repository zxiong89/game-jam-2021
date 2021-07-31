using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName ="WorldMap/CreatureType")]
public class CreatureType : ScriptableObject
{
    public bool IsBoss = false;
    public FloatRange Atk;
    public FloatRange Def;
    public float PhyResist;
    public float MagResist;
    public IntegerRange Exp;
    public IntegerRange Gold;
}
