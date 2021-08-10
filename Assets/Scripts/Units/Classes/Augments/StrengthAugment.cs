[System.Serializable]
public class StrengthAugment : BaseAugment
{
    public AugmentModifiers PowerAugment;
    public AugmentModifiers BrawnAugment;
    public AugmentModifiers BodyAugment;

    public override PartyStats AugmentPartyStats(BaseStat baseStat, PartyStats formationMod)
    {
        if (baseStat is StrengthStat stat)
        {
            return
                PowerAugment.AugmentPartyStat(stat.Power + stat.partyModifier, formationMod)
                + BrawnAugment.AugmentPartyStat(stat.Brawn + stat.partyModifier, formationMod)
                + BodyAugment.AugmentPartyStat(stat.Body + stat.partyModifier, formationMod);
        }
        return new PartyStats();
    }
}

