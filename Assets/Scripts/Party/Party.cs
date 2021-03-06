using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Party
{
    private const float SUPPORT_MOD_FACTOR = 10000f;

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

    public Quest FindQuestInCollection(QuestCollection quests)
    {
        foreach (var q in quests.Quests)
        {
            if (q.Party == this) return q;
        }
        return null;
    }

    public bool IsQuesting(QuestCollection activeQuests)
    {
        foreach (var q in activeQuests.Quests)
        {
            if (q.Party == this) return true;
        }
        return false;
    }

    public Quest StopQuesting(QuestCollection activeQuests)
    {
        var questToRemove = activeQuests.Quests.Find((quest) => quest.Party == this);
        if (questToRemove == null) return null;

        activeQuests.Quests.Remove(questToRemove);
        questToRemove.IsActive = false;
        return questToRemove;
    }

    public void GiveExp(int exp)
    {
        foreach(var u in FrontLine)
        {
            u.Experience += exp;
        }

        foreach(var u in BackLine)
        {
            u.Experience += exp;
        }
    }

    public float DealDamage(CreatureStats enemy, PartyStats globalMods)
    {
        var totalAtk = calcAtk(Stats.PhyAtk, Stats.AtkSup, globalMods.PhyAtk, enemy.PhyResist);
        totalAtk += calcAtk(Stats.MagAtk, Stats.AtkSup, globalMods.MagAtk, enemy.MagResist);
        return floorDamage(totalAtk - enemy.Def);
    }

    public float TakeDamage(CreatureStats enemy, PartyStats globalModifiers)
    {
        return floorDamage(enemy.Atk - (CalcTotalDef() * globalModifiers.Def));
    }

    private float floorDamage(float damage) => Mathf.Max(damage, 0f);

    public float CalcTotalAtk(PartyStats globalMods) => 
        calcAtk(Stats.PhyAtk, Stats.AtkSup, globalMods.PhyAtk) + calcAtk(Stats.MagAtk, Stats.AtkSup, globalMods.MagAtk);

    public float CalcTotalDef() =>
        Stats.Def * normalizeSupMod(Stats.DefSup);

    private float calcAtk(float baseAtk, float supMod, float globalMod, float resistMod = 0f)
    {
        if (resistMod >= 1f) return 0f;
        if (resistMod < 0f) resistMod = 0f;
        return (1 - resistMod) * normalizeSupMod(supMod) * globalMod * baseAtk;
    }

    private float normalizeSupMod(float supMod) => 1 + (supMod / SUPPORT_MOD_FACTOR);

    /// <summary>
    /// Returns a list of units in this party that are not in the other
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public List<Unit> UnitDifference(Party other)
    {
        var diff = new List<Unit>();

        foreach(var u in FrontLine) if (!other.Contains(u)) diff.Add(u);
        
        foreach (var u in BackLine) if (!other.Contains(u)) diff.Add(u);

        return diff;
    }

    public int UnitCount() => FrontLine.Count + BackLine.Count;

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