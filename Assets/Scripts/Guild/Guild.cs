using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Guild")]
public class Guild : ScriptableObject
{
    public List<Unit> Roster = new List<Unit>();

    public int Gold = 10000;
}
