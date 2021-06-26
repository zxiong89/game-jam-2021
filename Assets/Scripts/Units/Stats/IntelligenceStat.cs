public struct IntelligenceStat
{
    public float Intellect;
    public float Mind;
    public float Knowledge;

    public float Value
    {
        get
        {
            return (Intellect + Mind + Knowledge) / 3;
        }
    }
}
