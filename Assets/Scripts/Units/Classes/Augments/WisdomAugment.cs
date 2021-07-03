[System.Serializable]
public class WisdomAugment : BaseAugment
{
    public AugmentModifiers WillAugment;
    public AugmentModifiers SenseAugment;
    public AugmentModifiers SpiritAugment;

    public override PartyStats AugmentPartyStats(BaseStat baseStat, PartyStats formationMod)
    {
        if (baseStat is WisdomStat stat)
        {
            return 
                WillAugment.AugmentPartyStat(stat.Will, formationMod)
                + SenseAugment.AugmentPartyStat(stat.Sense, formationMod)
                + SpiritAugment.AugmentPartyStat(stat.Spirit, formationMod);
        }
        return new PartyStats();
    }
}

