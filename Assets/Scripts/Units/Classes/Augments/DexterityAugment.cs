[System.Serializable]
public class DexterityAugment : BaseAugment
{
    public AugmentModifiers SpeedAugment;
    public AugmentModifiers AgilityAugment;
    public AugmentModifiers ReflexesAugment;

    public override PartyStats AugmentPartyStats(BaseStat baseStat, PartyStats formationMod)
    {
        if (baseStat is DexterityStat stat)
        {
            return
                SpeedAugment.AugmentPartyStat(stat.Speed, formationMod)
                + AgilityAugment.AugmentPartyStat(stat.Agility, formationMod)
                + ReflexesAugment.AugmentPartyStat(stat.Reflexes, formationMod);
        }
        return new PartyStats();
    }
}

