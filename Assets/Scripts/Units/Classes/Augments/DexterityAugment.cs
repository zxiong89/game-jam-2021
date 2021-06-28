[System.Serializable]
public class DexterityAugment : BaseAugment
{
    public AugmentModifiers SpeedAugment;
    public AugmentModifiers AgilityAugment;
    public AugmentModifiers ReflexesAugment;

    public override void AugmentPartyStats(PartyStats party, BaseStat baseStat, PartyStats formationMod)
    {
        if (baseStat is DexterityStat stat)
        {
            SpeedAugment.AugmentPartyStat(party, stat.Speed, formationMod);
            AgilityAugment.AugmentPartyStat(party, stat.Agility, formationMod);
            ReflexesAugment.AugmentPartyStat(party, stat.Reflexes, formationMod);
        }
    }
}

