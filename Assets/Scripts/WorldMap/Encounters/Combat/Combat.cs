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

    public override string LogString() => stats.Name;

    public override bool IsComplete() => hp <= 0;

    public override EncounterResults Run(Party party, int turns, PartyStats globalMods)
    {
        float dealt = party.DealDamage(stats, globalMods);
        float taken = party.TakeDamage(stats, globalMods);
        int turnsNeeded = Mathf.CeilToInt(hp / dealt);

        if (turnsNeeded > turns)
        {
            hp -= dealt * turns;
            return new EncounterResults()
            {
                turnsRemaining = 0,
                DamageTaken = taken * turns
            };
        }

        hp = 0;
        return new EncounterResults()
        {
            turnsRemaining = turns - turnsNeeded,
            DamageTaken = taken * turnsNeeded,
            GoldGained = stats.Gold,
            ExpGained = stats.Exp
        };
    }
}
