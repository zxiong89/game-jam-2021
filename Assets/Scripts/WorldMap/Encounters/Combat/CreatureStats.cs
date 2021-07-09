using UnityEngine;

[System.Serializable]
public struct CreatureStats
{
    public string Name;
    public float Hp;
    public float Atk;
    public float Def;
    public float PhyResist;
    public float MagResist;
    public float Exp;
    public float Gold;

    public static CreatureStats Create(CombatData data)
    {
        if (data.Creatures == null || data.Creatures.Length < 0) 
        {
            Debug.LogError("Empty creatures for a given combat data");
            return new CreatureStats(); 
        }

        int i = Random.Range(0, data.Creatures.Length - 1);
        var type = data.Type;
        float def = FloatRange.Random(type.Def);
        return new CreatureStats()
        {
            Name = data.Creatures[i],
            Hp = def,
            Atk = FloatRange.Random(type.Atk),
            Def = def,
            PhyResist = type.PhyResist,
            MagResist = type.MagResist,
            Exp = FloatRange.Random(type.Exp),
            Gold = FloatRange.Random(type.Gold)
        };
    }
}
