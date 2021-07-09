using UnityEngine;

public class Exploration : Encounter
{
    private const float PARTY_TICK_FACTOR = 2000f;
    public ExplorationStats Stats;
    public float time;

    public Exploration(ExplorationData data)
    {
        Stats = ExplorationStats.Create(data);
        time = Stats.Time;
    }

    public override float GetExp() => Stats.Exp;

    public override float GetGold() => Stats.Gold;

    public override bool IsComplete() => time <= 0f;

    public override string LogString() => Stats.Description;

    public override int Run(Party party, int ticks)
    {
        var tickRate = calcPartyTickFactor(party) + ticks;
        int ticksNeeded = Mathf.CeilToInt(time / tickRate);

        if (ticks >= ticksNeeded)
        {
            time = 0;
            return ticks - ticksNeeded;
        }

        time -= ticks * tickRate;

        return 0;
    }

    private float calcPartyTickFactor(Party party) =>
        (party.CalcTotalAtk() + party.CalcTotalDef()) / PARTY_TICK_FACTOR; 
}
