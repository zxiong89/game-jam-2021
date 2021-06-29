[System.Serializable]
public class UnitClass 
{
    public UnitClassData Data;

    public UnitClass(UnitClassData data)
    {
        Data = data;
    }

    public virtual PartyStats CalcContribution(StatBlock player, bool isFrontline)
    {
        PartyStats stats = new PartyStats();
        PartyStats lineMod = isFrontline ? Data.FrontlineMod : Data.BacklineMod;
        Data.Str.AugmentPartyStats(stats, player.Str, lineMod);
        Data.Con.AugmentPartyStats(stats, player.Con, lineMod);
        Data.Dex.AugmentPartyStats(stats, player.Dex, lineMod);
        Data.Int.AugmentPartyStats(stats, player.Int, lineMod);
        Data.Wis.AugmentPartyStats(stats, player.Wis, lineMod);
        return stats;
    }

}
