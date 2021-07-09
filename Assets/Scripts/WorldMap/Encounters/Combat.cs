using UnityEngine;

public class Combat : Encounter
{
    private CreatureStats stats;
    private float hp;

    public Combat(CombatData data)
    {
        stats = CreatureStats.Create(data);
        hp = stats.Hp; 
    }

    public override float GetExp() => stats.Exp;

    public override float GetGold() => stats.Gold;

    public override bool IsComplete() => hp <= 0f;

    public override string LogString() => stats.Name;

    public override int Run(Party party, int ticks)
    {
        float dealt = party.DealDamage(stats);
        float taken = party.TakeDamage(stats);
        int ticksNeeded = Mathf.CeilToInt(hp / dealt);

        if (ticksNeeded >= ticks)
        {
            hp -= dealt * ticks;
            return 0;
        }

        hp = 0;
        return ticks - ticksNeeded;
    }
}
