public struct WisdomStat
{
    public float Will;
    public float Sense;
    public float Spirit;

    public float Value
    {
        get
        {
            return (Will + Sense + Spirit) / 3;
        }
    }
}
