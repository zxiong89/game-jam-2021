[System.Serializable]
public class ConstitutionAugment : BaseAugment
{
    public AugmentModifiers StaminaAugment;
    public AugmentModifiers EnduranceAugment;
    public AugmentModifiers VitalityAugment;

    public override PartyStats AugmentPartyStats(BaseStat baseStat, PartyStats formationMod)
    {
        if (baseStat is ConstitutionStat stat)
        {
            return 
                StaminaAugment.AugmentPartyStat(stat.Stamina, formationMod)
                + EnduranceAugment.AugmentPartyStat(stat.Endurance, formationMod)
                + VitalityAugment.AugmentPartyStat(stat.Vitality, formationMod);
        }
        return new PartyStats();
    }
}

