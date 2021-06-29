using Unity.Mathematics;

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
        }
    }

    public int Age;
    public StatBlock Stats;
    public UnitClass Class;

    #endregion

    #region Constructors

    public Unit(string name, int level, int age, StatBlock stats)
    {
        DisplayName = name;
        Level = level;
        Age = age;
        Stats = stats;
    }

    #endregion

    #region Methods

    public void LevelUp() => Level++;

    public PartyStats CalcContribution(bool isFrontline) => Class.CalcContribution(Stats, isFrontline);

    #endregion
}
