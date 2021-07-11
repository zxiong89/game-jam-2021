﻿using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

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
            Stats?.UpdateStats(level);
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
        Level = level;
        Age = age;
        Stats = stats;
        Class = new UnitClass(data);
        Traits = traits;
    }

    #endregion

    #region Methods

    public void LevelUp() => Level++;

    public PartyStats CalcContribution(bool isFrontline) => Class.CalcContribution(Stats, isFrontline);

    public void Retire()
    {
        if (ParentRoster.RosterType == Roster.Guild || ParentRoster.RosterType == Roster.Party) {
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
