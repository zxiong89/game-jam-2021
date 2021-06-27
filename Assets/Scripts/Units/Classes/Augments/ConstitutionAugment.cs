[System.Serializable]
public class ConstitutionAugment : BaseAugment
{
    public AugmentModifiers StaminaAugment;
    public AugmentModifiers EnduranceAugment;
    public AugmentModifiers VitalityAugment;

    public override void AugmentPartyStats(PartyStats party, BaseStat baseStat)
    {
        if (baseStat is ConstitutionStat stat)
        {
            StaminaAugment.AugmentPartyStat(party, stat.Stamina);
            EnduranceAugment.AugmentPartyStat(party, stat.Endurance);
            VitalityAugment.AugmentPartyStat(party, stat.Vitality);
        }
    }
}

