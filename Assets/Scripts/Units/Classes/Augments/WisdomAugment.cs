[System.Serializable]
public class WisdomAugment : BaseAugment
{
    public AugmentModifiers WillAugment;
    public AugmentModifiers SenseAugment;
    public AugmentModifiers SpiritAugment;

    public override void AugmentPartyStats(PartyStats party, BaseStat baseStat, PartyStats formationMod)
    {
        if (baseStat is WisdomStat stat)
        {
            WillAugment.AugmentPartyStat(party, stat.Will, formationMod);
            SenseAugment.AugmentPartyStat(party, stat.Sense, formationMod);
            SpiritAugment.AugmentPartyStat(party, stat.Spirit, formationMod);
        }
    }
}

