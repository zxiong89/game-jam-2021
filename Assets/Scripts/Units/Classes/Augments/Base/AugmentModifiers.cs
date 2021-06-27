public struct AugmentModifiers 
{
    public float PhyAtkMod;
    public float MagAtkMod;
    public float DefMod;
    public float AtkSupMod;
    public float DefSupMod;

    public AugmentModifiers(float phyAtkMod, float magAtkMod, float defMod, float atkSupMod, float defSupMod)
    {
        PhyAtkMod = phyAtkMod;
        MagAtkMod = magAtkMod;
        DefMod = defMod;
        AtkSupMod = atkSupMod;
        DefSupMod = defSupMod;
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
