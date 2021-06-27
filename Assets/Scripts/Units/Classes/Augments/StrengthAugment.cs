[System.Serializable]
public class StrengthAugment : BaseAugment
{
    public AugmentModifiers PowerAugment;
    public AugmentModifiers BrawnAugment;
    public AugmentModifiers BodyAugment;

    public override void AugmentPartyStats(PartyStats party, BaseStat baseStat)
    {
        if (baseStat is StrengthStat stat)
        {
            PowerAugment.AugmentPartyStat(party, stat.Power);
            BrawnAugment.AugmentPartyStat(party, stat.Brawn);
            BodyAugment.AugmentPartyStat(party, stat.Body);
        }
    }
}

