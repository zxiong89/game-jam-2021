[System.Serializable]
public class IntelligenceAugment : BaseAugment
{
    public AugmentModifiers IntellectAugment;
    public AugmentModifiers MindAugment;
    public AugmentModifiers KnowledgeAugment;

    public override PartyStats AugmentPartyStats(BaseStat baseStat, PartyStats formationMod)
    {
        if (baseStat is IntelligenceStat stat)
        {
            return 
                IntellectAugment.AugmentPartyStat(stat.Intellect + stat.partyModifier, formationMod)
                + MindAugment.AugmentPartyStat(stat.Mind + stat.partyModifier, formationMod)
                + KnowledgeAugment.AugmentPartyStat(stat.Knowledge + stat.partyModifier, formationMod);
        }
        return new PartyStats();
    }
}

