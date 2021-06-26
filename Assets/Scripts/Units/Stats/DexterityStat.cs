public struct DexterityStat
{
    public float Speed;
    public float Agility;
    public float Reflexes;

    public float Value
    {
        get
        {
            return (Speed + Agility + Reflexes) / 3;
        }
    }
}
