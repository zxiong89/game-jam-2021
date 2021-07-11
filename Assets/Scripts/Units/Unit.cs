using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[System.Serializable]
public class Unit
{
    #region Fields/Properties
    public string DisplayName { get; set; }

    private int level;
    public int Level
    {
        get => level;
        set
        {
            level = value;
            Stats?.UpdateStats(level, traitModifiers);
            recruitmentData = null;
            ExperienceToLevel = (int)math.pow(level, 3);
        }
    }

    public int ExperienceToLevel { get; private set; }


    private int experience;
    public int Experience
    {
        get { return experience; }
        set { 
            experience = value;
            while(experience > ExperienceToLevel)
            {
                experience -= ExperienceToLevel;
                Level++;
            }
        }
    }

    public int Age;
    public StatBlock Stats;
    public UnitClass Class;

    public List<Trait> Traits = new List<Trait>();
    private int[] traitModifiers = new int[5] { 0, 0, 0, 0, 0 };

    public int[] TraitModifiers
    {
        get { return traitModifiers; }
        private set
        {
            traitModifiers = value;
            Stats?.UpdateStats(Level, TraitModifiers);
        }
    }


    public UnitRoster ParentRoster;
    public bool IsRetired = false;

    private RecruitmentData recruitmentData = null;

    public RecruitmentData RecruitmentData
    {
        get { 
            if(recruitmentData == null) recruitmentData = new RecruitmentData(this);
            return recruitmentData; 
        }
        private set { recruitmentData = value; }
    }

    #endregion

    #region Constructors

    public Unit(string name, int level, int age, StatBlock stats, UnitClassData data, List<Trait> traits)
    {
        DisplayName = name;
        Age = age;
        Stats = stats;
        Class = new UnitClass(data);
        Traits = traits;
        CalcTraitModifiers();
        Level = level;
    }

    #endregion

    #region Methods

    public void LevelUp() => Level++;

    public PartyStats CalcContribution(bool isFrontline) => Class.CalcContribution(Stats, isFrontline);

    private void CalcTraitModifiers()
    {
        var modifiers = new int[5];
        foreach(var trait in Traits)
        {
            for (int i = 0; i < modifiers.Length; i++)
            {
                modifiers[i] += trait.StatModifiers[i];
            }
        }
        TraitModifiers = modifiers;
    }

    public bool IsApprentice()
    {
        return Age <= 24;
    }

    public bool IsInPlayerGuild()
    {
        Roster rosterType = ParentRoster.RosterType;
        return rosterType == Roster.Guild || rosterType == Roster.Party;
    }

    public void Retire()
    {
        if (IsInPlayerGuild()) {
            EventLog.AddMessage(DisplayName + " has retired." );
        }
        FreeUnit();
        IsRetired = true;
    }

    public void FreeUnit()
    {
        if(ParentRoster != null)
        {
            ParentRoster.Remove(this);
        }
    }
    #endregion
}
