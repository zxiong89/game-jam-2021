[System.Serializable]
public struct EnemyStats
{
    public string Creature;
    public float Hp;
    public float Atk;
    public float Def;
    public float PhyResist;
    public float MagResist;
    public float Exp;
    public float Gold;

    public static EnemyStats Create(CombatData data)
    {
        float def = FloatRange.Random(data.Def);
        return new EnemyStats()
        {
            Hp = def,
            Atk = FloatRange.Random(data.Atk),
            Def = def,
            PhyResist = data.PhyResist,
            MagResist = data.MagResist,
            Exp = FloatRange.Random(data.Exp),
            Gold = FloatRange.Random(data.Gold)
        };
    }
}
