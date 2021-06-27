[System.Serializable]
public class WisdomAugment : BaseAugment
{
    public AugmentModifiers WillAugment;
    public AugmentModifiers SenseAugment;
    public AugmentModifiers SpiritAugment;

    public override void AugmentPartyStats(PartyStats party, BaseStat baseStat)
    {
        if (baseStat is WisdomStat stat)
        {
            WillAugment.AugmentPartyStat(party, stat.Will);
            SenseAugment.AugmentPartyStat(party, stat.Sense);
            SpiritAugment.AugmentPartyStat(party, stat.Spirit);
        }
    }
}

