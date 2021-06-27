public class IntelligenceAugment : BaseAugment
{
    public AugmentModifiers IntellectAugment;
    public AugmentModifiers MindAugment;
    public AugmentModifiers KnowledgeAugment;

    public override void AugmentPartyStats(PartyStats party, BaseStat baseStat)
    {
        if (baseStat is IntelligenceStat stat)
        {
            IntellectAugment.AugmentPartyStat(party, stat.Intellect);
            MindAugment.AugmentPartyStat(party, stat.Mind);
            KnowledgeAugment.AugmentPartyStat(party, stat.Knowledge);
        }
    }
}

