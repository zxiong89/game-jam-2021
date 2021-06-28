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

    public void AugmentPartyStat(PartyStats party, float stat, PartyStats formationMod)
    {
        party.PhyAtk += formationMod.PhyAtk * augmentStat(PhyAtkMod, stat, formationMod.PhyAtk);
        party.MagAtk += augmentStat(MagAtkMod, stat, formationMod.MagAtk);
        party.Def += augmentStat(DefMod, stat, formationMod.Def);
        party.AtkSup += augmentStat(AtkSupMod, stat, formationMod.AtkSup);
        party.DefSup += augmentStat(DefSupMod, stat, formationMod.DefSup);
    }

    private float augmentStat(float bonus, float stat, float mod) => mod > 0 ? mod *(1 + bonus) * stat : 0f;
}
