[System.Serializable]
public class UnitClass 
{
    protected StrengthAugment Str;
    protected ConstitutionAugment Con;
    protected DexterityAugment Dex;
    protected IntelligenceAugment Int;
    protected WisdomAugment Wis;

    public UnitClass(StrengthAugment str_aug, ConstitutionAugment con_aug,
        DexterityAugment dex_aug, IntelligenceAugment int_aug, WisdomAugment wis_aug)
    {
        Str = str_aug;
        Con = con_aug;
        Dex = dex_aug;
        Int = int_aug;
        Wis = wis_aug;
    }

    public virtual PartyStats CalcContribution(StatBlock block)
    {
        PartyStats stats = new PartyStats();
        Str.AugmentPartyStats(stats, block.Str);
        Con.AugmentPartyStats(stats, block.Con);
        Dex.AugmentPartyStats(stats, block.Dex);
        Int.AugmentPartyStats(stats, block.Int);
        Wis.AugmentPartyStats(stats, block.Wis);
        return stats;
    }

}
