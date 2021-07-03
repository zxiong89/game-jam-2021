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
                PowerAugment.AugmentPartyStat(stat.Power, formationMod)
                + BrawnAugment.AugmentPartyStat(stat.Brawn, formationMod)
                + BodyAugment.AugmentPartyStat(stat.Body, formationMod);
        }
        return new PartyStats();
    }
}

