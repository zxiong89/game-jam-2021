using System.Collections.Generic;
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
        }
    }

    private int experience;

    public int Experience
    {
        get { return experience; }
        set { 
            experience = value;
            if(experience > 100)
            {
                Level += experience / 100;
                experience %= 100;
            }
        }
    }

    public int Age;
    public StatBlock Stats;
    public UnitClass Class;

    public List<Trait> Traits = new List<Trait>()
    {
        new Trait() { Name = "Sleepy", Description = "zzz", Color = Color.yellow },
        new Trait() { Name = "Verbose", Description = "A long string of text to make the text wrap and ensure the text still looks good when it is wrapping inside the traits group.", Color = Color.red },
        new Trait() { Name = "Surprised", Description = "O.O O.O", Color = Color.green }
    };

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

    public Unit(string name, int level, int age, StatBlock stats, UnitClassData data)
    {
        DisplayName = name;
        Level = level;
        Age = age;
        Stats = stats;
        Class = new UnitClass(data);
    }

    #endregion

    #region Methods

    public void LevelUp() => Level++;

    public PartyStats CalcContribution(bool isFrontline) => Class.CalcContribution(Stats, isFrontline);

    public void Retire()
    {
        FreeUnit();
        IsRetired = true;
    }

    public void FreeUnit()
    {
        if(ParentRoster != null)
        {
            ParentRoster.Remove(this);
            ParentRoster = null;
        }
    }
    #endregion
}
