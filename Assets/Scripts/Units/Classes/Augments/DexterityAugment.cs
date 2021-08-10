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
                SpeedAugment.AugmentPartyStat(stat.Speed + stat.partyModifier, formationMod)
                + AgilityAugment.AugmentPartyStat(stat.Agility + stat.partyModifier, formationMod)
                + ReflexesAugment.AugmentPartyStat(stat.Reflexes + stat.partyModifier, formationMod);
        }
        return new PartyStats();
    }
}

