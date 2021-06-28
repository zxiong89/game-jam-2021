[System.Serializable]
public class StrengthAugment : BaseAugment
{
    public AugmentModifiers PowerAugment;
    public AugmentModifiers BrawnAugment;
    public AugmentModifiers BodyAugment;

    public override void AugmentPartyStats(PartyStats party, BaseStat baseStat, PartyStats formationMod)
    {
        if (baseStat is StrengthStat stat)
        {
            PowerAugment.AugmentPartyStat(party, stat.Power, formationMod);
            BrawnAugment.AugmentPartyStat(party, stat.Brawn, formationMod);
            BodyAugment.AugmentPartyStat(party, stat.Body, formationMod);
        }
    }
}

