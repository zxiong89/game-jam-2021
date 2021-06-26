
[System.Serializable]
public class StatBlock
{
    public StrengthStat Str;

    public ConstitutionStat Con;

    public DexterityStat Dex;

    public IntelligenceStat Int;

    public WisdomStat Wis;

    public void UpdateStats(int level)
    {
        Str.Update(level);
        Con.Update(level);
        Dex.Update(level);
        Int.Update(level);
        Wis.Update(level);
    }
}
