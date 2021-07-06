using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyLine
{
    #region Constants
    public const int MAX_SIZE = 3;
    #endregion

    #region Fields/Properties

    private List<Unit> units = new List<Unit>();
    public IReadOnlyList<Unit> Units { get => units; }

    #endregion

    #region Methods
    public bool Contains(Unit unit) => units.Contains(unit);

    public bool HasRoom() => (units.Count < MAX_SIZE);

    public bool AddUnit(Unit unit)
    {
        if (!HasRoom()) return false;
        units.Add(unit);
        return true;
    }

    public bool RemoveUnit(Unit unit) => units.Remove(unit);
    #endregion
}
