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
                IntellectAugment.AugmentPartyStat(stat.Intellect, formationMod)
                + MindAugment.AugmentPartyStat(stat.Mind, formationMod)
                + KnowledgeAugment.AugmentPartyStat(stat.Knowledge, formationMod);
        }
        return new PartyStats();
    }
}

