using System.Collections.Generic;

[System.Serializable]
public class Party
{
    #region Fields/Properties
    public string Name = "Party";

    private PartyLine frontLine = new PartyLine();
    public IReadOnlyList<Unit> FrontLine { get => frontLine.Units; }

    private PartyLine backLine = new PartyLine();
    public IReadOnlyList<Unit> BackLine { get => backLine.Units; }

    private PartyStats stats = new PartyStats();
    public ref readonly PartyStats Stats => ref stats;
    #endregion

    #region Constructors
    public Party()
    {

    }

    public Party(Party copy)
    {
        Name = copy.Name;
        foreach(var u in copy.frontLine.Units)
        {
            frontLine.AddUnit(u);
        }

        foreach (var u in copy.backLine.Units)
        {
            backLine.AddUnit(u);
        }
    }
    #endregion

    #region Methods

    public bool Contains(Unit unit) => frontLine.Contains(unit) || backLine.Contains(unit);

    /// <summary>
    /// Update Party Stats
    /// </summary>
    public void UpdatePartyStats()
    {
        stats = new PartyStats();
        foreach (var f in frontLine.Units)
        {
            stats += f.CalcContribution(true);
        }
        foreach (var b in backLine.Units)
        {
            stats += b.CalcContribution(false);
        }
    }

    /// <summary>
    /// Add a unit to the party in the first available line (front->back).
    /// This will update the party stats
    /// </summary>
    /// <param name="unit"></param>
    /// <returns>true if the unit was added, false otherwise</returns>
    public bool AddUnit(Unit unit)
    {
        if (AddToFrontLine(unit)) return true;
        return AddToBackLine(unit);
    }

    /// <summary>
    /// Add a unit to the party in the firstline
    /// This will update the party stats
    /// </summary>
    /// <param name="unit"></param>
    /// <returns>true if the unit was added, false otherwise</returns>
    public bool AddToFrontLine(Unit unit)
    {
        if (!frontLine.AddUnit(unit)) return false;

        stats += unit.CalcContribution(true);

        return true;
    }

    /// <summary>
    /// Add a unit to the party in the backline
    /// This will update the party stats
    /// </summary>
    /// <param name="unit"></param>
    /// <returns>true if the unit was added, false otherwise</returns>
    public bool AddToBackLine(Unit unit)
    {
        if (!backLine.AddUnit(unit)) return false;

        stats += unit.CalcContribution(false);

        return true;
    }


    /// <summary>
    /// Remove a unit from the party.
    /// This will update the party stats
    /// </summary>
    /// <param name="unit"></param>
    /// <returns>true if the unit was removed, false otherwise</returns>
    public bool RemoveUnit(Unit unit)
    {
        if (unit == null) return false;
        if (frontLine.RemoveUnit(unit))
        {
            stats -= unit.CalcContribution(true);
            return true;
        }

        if (backLine.RemoveUnit(unit))
        {
            stats -= unit.CalcContribution(false);
            return true;
        }

        return false;
    }


    #endregion
}