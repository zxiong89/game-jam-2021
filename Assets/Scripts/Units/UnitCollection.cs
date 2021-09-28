using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Units/UnitCollection")]
public class UnitCollection : ScriptableObject
{
    public MinSortedYearlyEventQueue<Unit> Units { get; private set; } = new MinSortedYearlyEventQueue<Unit>();
}
