[System.Serializable]
public struct FloatRange
{
    public float Min;
    public float Max;

    public static float Random(FloatRange range)
    {
        return UnityEngine.Random.Range(range.Min, range.Max);
    }
}
