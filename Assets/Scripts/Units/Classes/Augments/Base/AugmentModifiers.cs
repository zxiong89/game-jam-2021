[System.Serializable]
public struct AugmentModifiers 
{
    public float PhyAtkMod;
    public float MagAtkMod;
    public float DefMod;
    public float AtkSupMod;
    public float DefSupMod;

    public AugmentModifiers(AugmentModifiers copy)
    {
        PhyAtkMod = copy.PhyAtkMod;
        MagAtkMod = copy.MagAtkMod;
        DefMod = copy.DefMod;
        AtkSupMod = copy.AtkSupMod;
        DefSupMod = copy.DefSupMod;
    }

    public PartyStats AugmentPartyStat(float stat, PartyStats formationMod)
    {
        return new PartyStats
        {
            PhyAtk = augmentStat(PhyAtkMod, stat, formationMod.PhyAtk),
            MagAtk = augmentStat(MagAtkMod, stat, formationMod.MagAtk),
            Def = augmentStat(DefMod, stat, formationMod.Def),
            AtkSup = augmentStat(AtkSupMod, stat, formationMod.AtkSup),
            DefSup = augmentStat(DefSupMod, stat, formationMod.DefSup)
        };
    }

    private float augmentStat(float bonus, float stat, float mod) => mod > 0 ? mod *(1 + bonus) * stat : 0f;
}
