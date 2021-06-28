[System.Serializable]
public class IntelligenceAugment : BaseAugment
{
    public AugmentModifiers IntellectAugment;
    public AugmentModifiers MindAugment;
    public AugmentModifiers KnowledgeAugment;

    public override void AugmentPartyStats(PartyStats party, BaseStat baseStat, PartyStats formationMod)
    {
        if (baseStat is IntelligenceStat stat)
        {
            IntellectAugment.AugmentPartyStat(party, stat.Intellect, formationMod);
            MindAugment.AugmentPartyStat(party, stat.Mind, formationMod);
            KnowledgeAugment.AugmentPartyStat(party, stat.Knowledge, formationMod);
        }
    }
}

