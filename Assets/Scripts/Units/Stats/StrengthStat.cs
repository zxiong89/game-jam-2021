public struct StrengthStat
{
    public float Power;
    public float Brawn;
    public float Body;

    public float Value
    {
        get
        {
            return (Power + Brawn + Body) / 3;
        }
    }
}
