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
        PartyStats lineMod = isFrontline ? Data.FrontlineMod : Data.BacklineMod;
        PartyStats stats = 
            Data.Str.AugmentPartyStats(player.Str, lineMod)
            + Data.Con.AugmentPartyStats(player.Con, lineMod)
            + Data.Dex.AugmentPartyStats(player.Dex, lineMod)
            + Data.Int.AugmentPartyStats(player.Int, lineMod)
            + Data.Wis.AugmentPartyStats(player.Wis, lineMod);
        return stats;
    }

}
