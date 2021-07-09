[System.Serializable]
public struct ExplorationStats
{
    public string Description;
    public float Time;
    public float Exp;
    public float Gold;

    public static ExplorationStats Create(ExplorationData data)
    {
        return new ExplorationStats()
        {
            Description = data.Description,
            Time = FloatRange.Random(data.Time),
            Exp = FloatRange.Random(data.Exp),
            Gold = FloatRange.Random(data.Gold)
        };
    }
}
