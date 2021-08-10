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
                StaminaAugment.AugmentPartyStat(stat.Stamina + stat.partyModifier, formationMod)
                + EnduranceAugment.AugmentPartyStat(stat.Endurance + stat.partyModifier, formationMod)
                + VitalityAugment.AugmentPartyStat(stat.Vitality + stat.partyModifier, formationMod);
        }
        return new PartyStats();
    }
}

