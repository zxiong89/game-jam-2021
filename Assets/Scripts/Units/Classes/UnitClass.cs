[System.Serializable]
public class UnitClass 
{
    public UnitClassData Data;

    public UnitClass()
    {
    }

    public virtual PartyStats CalcContribution(StatBlock player)
    {
        PartyStats stats = new PartyStats();
        Data.Str.AugmentPartyStats(stats, player.Str);
        Data.Con.AugmentPartyStats(stats, player.Con);
        Data.Dex.AugmentPartyStats(stats, player.Dex);
        Data.Int.AugmentPartyStats(stats, player.Int);
        Data.Wis.AugmentPartyStats(stats, player.Wis);
        return stats;
    }

}
