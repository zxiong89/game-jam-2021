using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Keeps track of all units. Rosters are mutually exclusive
/// </summary>
[System.Serializable]
public class UnitRosterManager
{
    public UnitRoster InPartyRoster;

    public UnitRoster GuildRoster;

    public void Clear()
    {
        InPartyRoster.Clear();
        GuildRoster.Clear();
    }
}
