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
        party.PhyAtk += PhyAtkMod * stat;
        party.MagAtk += MagAtkMod * stat;
        party.Def += DefMod * stat;
        party.AtkSup += AtkSupMod * stat;
        party.DefSup += DefSupMod * stat;
    }
}
