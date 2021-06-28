using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Units/ClassSelection")]
[System.Serializable]
public class UnitClassSelection : ScriptableObject
{
    public UnitClassData[] Classes;
}
