[System.Serializable]
public struct PartyStats 
{
    public float PhyAtk;
    public float MagAtk;
    public float Def;
    public float AtkSup;
    public float DefSup;

    public float Atk => PhyAtk + MagAtk;

    public PartyStats(PartyStats copy)
    {
        PhyAtk = copy.PhyAtk;
        MagAtk = copy.MagAtk;
        Def = copy.Def;
        AtkSup = copy.AtkSup;
        DefSup = copy.DefSup;
    }

    public static PartyStats operator +(PartyStats a) => a;
    public static PartyStats operator +(PartyStats a, PartyStats b)
    {
        return new PartyStats
        {
            PhyAtk = a.PhyAtk + b.PhyAtk,
            MagAtk = a.MagAtk + b.MagAtk,
            Def = a.Def + b.Def,
            AtkSup = a.AtkSup + b.AtkSup,
            DefSup = a.DefSup + b.DefSup
        };
    }
    public static PartyStats operator -(PartyStats a)
    {
        return new PartyStats
        {
            PhyAtk = -a.PhyAtk,
            MagAtk = -a.MagAtk,
            Def = -a.Def,
            AtkSup = -a.AtkSup,
            DefSup = -a.DefSup
        };
    }

    public static PartyStats operator -(PartyStats a, PartyStats b)
    {
        return new PartyStats
        {
            PhyAtk = a.PhyAtk - b.PhyAtk,
            MagAtk = a.MagAtk - b.MagAtk,
            Def = a.Def - b.Def,
            AtkSup = a.AtkSup - b.AtkSup,
            DefSup = a.DefSup - b.DefSup
        };
    }
}
