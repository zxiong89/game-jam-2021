public struct ConstitutionStat
{
    public float Stamina;
    public float Endurance;
    public float Vitality;

    public float Value
    {
        get
        {
            return (Stamina + Endurance + Vitality) / 3;
        }
    }
}
