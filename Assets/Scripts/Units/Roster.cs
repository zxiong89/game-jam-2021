using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Units/Roster")]
public class Roster : ScriptableObject
{
    private List<Unit> units = new List<Unit>();
    public List<Unit> Units
    {
        get { return units; }
        set { units = value; }
    }
}