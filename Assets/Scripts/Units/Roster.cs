using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Units/Roster")]
public class Roster : ScriptableObject
{
    public List<Unit> Units { get; set; }
}