﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A mutually exclusive collection of units.
/// A unit can only be in one roster at a time.
/// </summary>
[CreateAssetMenu(menuName = ("Units/Roster"))]
public class UnitRoster : ScriptableObject, IEnumerable<Unit>
{
    List<Unit> Roster = new List<Unit>();

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Roster.GetEnumerator();
    }

    public IEnumerator<Unit> GetEnumerator()
    {
        return Roster.GetEnumerator();
    }

    public void Add(Unit unitToAdd)
    {
        unitToAdd.FreeUnit();
        Roster.Add(unitToAdd);
        unitToAdd.ParentRoster = this;
    }

    public void Remove(Unit unitToRemove)
    {
        Roster.Remove(unitToRemove);
        unitToRemove.ParentRoster = null;
    }

    public int Count { 
        get => Roster.Count;
    }

    public Unit this[int index] { get => Roster[index]; }

    public List<Unit> FindAll(System.Predicate<Unit> match)
    {
        return Roster.FindAll(match);
    }
}