using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Keeps track of all units. Rosters are mutually exclusive
/// </summary>
public class UnitLocationManager
{
    public List<Unit> AllUnits { get; } = new List<Unit>();

    public UnitRoster FreeAgentRoster { get; } = new UnitRoster();

    public UnitRoster GuildRoster { get; } = new UnitRoster();

    public UnitRoster ApprenticeShopRoster { get; } = new UnitRoster();

    public UnitRoster ExperiencedShopRoster { get; } = new UnitRoster();

    public UnitRoster ExpertShopRoster { get; } = new UnitRoster();

    public UnitRoster VeterShopRoster { get; } = new UnitRoster();
}
