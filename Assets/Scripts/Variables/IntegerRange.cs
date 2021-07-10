[System.Serializable]
public struct IntegerRange
{
    public int Min;
    public int Max;

    public static int Random(IntegerRange range)
    {
        return UnityEngine.Random.Range(range.Min, range.Max+1);
    }
}
