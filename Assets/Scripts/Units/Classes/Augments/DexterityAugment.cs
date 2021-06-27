public class DexterityAugment : BaseAugment
{
    public AugmentModifiers SpeedAugment;
    public AugmentModifiers AgilityAugment;
    public AugmentModifiers ReflexesAugment;

    public override void AugmentPartyStats(PartyStats party, BaseStat baseStat)
    {
        if (baseStat is DexterityStat stat)
        {
            SpeedAugment.AugmentPartyStat(party, stat.Speed);
            AgilityAugment.AugmentPartyStat(party, stat.Agility);
            ReflexesAugment.AugmentPartyStat(party, stat.Reflexes);
        }
    }
}

