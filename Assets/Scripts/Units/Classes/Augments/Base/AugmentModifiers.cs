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

    public void AugmentPartyStat(PartyStats party, float stat)
    {
        party.PhyAtk += augmentStat(PhyAtkMod, stat);
        party.MagAtk += augmentStat(MagAtkMod, stat);
        party.Def += augmentStat(DefMod, stat);
        party.AtkSup += augmentStat(AtkSupMod, stat);
        party.DefSup += augmentStat(DefSupMod, stat);
    }

    private float augmentStat(float mod, float stat) => (1 + mod) * stat;
}
