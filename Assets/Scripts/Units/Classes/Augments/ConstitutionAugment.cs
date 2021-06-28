[System.Serializable]
public class ConstitutionAugment : BaseAugment
{
    public AugmentModifiers StaminaAugment;
    public AugmentModifiers EnduranceAugment;
    public AugmentModifiers VitalityAugment;

    public override void AugmentPartyStats(PartyStats party, BaseStat baseStat, PartyStats formationMod)
    {
        if (baseStat is ConstitutionStat stat)
        {
            StaminaAugment.AugmentPartyStat(party, stat.Stamina, formationMod);
            EnduranceAugment.AugmentPartyStat(party, stat.Endurance, formationMod);
            VitalityAugment.AugmentPartyStat(party, stat.Vitality, formationMod);
        }
    }
}

