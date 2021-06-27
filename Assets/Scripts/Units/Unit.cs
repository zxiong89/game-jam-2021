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

    #endregion

    #region Constructors

    public Unit(int level, int age, StatBlock stats)
    {
        Level = level;
        Age = age;
        Stats = stats;
    }

    #endregion

    #region Methods

    public void LevelUp() => Level++;

    #endregion
}
