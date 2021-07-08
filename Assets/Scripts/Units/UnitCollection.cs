using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Units/UnitCollection")]
public class UnitCollection : ScriptableObject
{
    public List<Unit> Units { get; } = new List<Unit>();
}
