using UnityEngine;

public class Exploration : Encounter
{
    private const float PARTY_EXPLORATION_TURN_FACTOR = 2000f;
    private ExplorationStats stats;
    private float time;

    public Exploration(ExplorationData data)
    {
        stats = ExplorationStats.Create(data);
        time = stats.Time;
    }

    public override string LogString() => stats.Description;

    public override bool IsComplete() => time <= 0;

    public override EncounterResults Run(Party party, int turns, PartyStats globalMods)
    {
        var explorationPerTurn = calcExplorationPerTurn(party, globalMods) + turns;
        int turnsNeeded = Mathf.CeilToInt(time / explorationPerTurn);

        if (turns >= turnsNeeded)
        {
            time = 0;
            return new EncounterResults()
            {
                turnsRemaining = turns - turnsNeeded,
                GoldGained = stats.Gold,
                ExpGained = stats.Exp
            };
        }

        time -= turns * explorationPerTurn;

        return new EncounterResults()
        {
            turnsRemaining = 0
        };
    }

    private float calcExplorationPerTurn(Party party, PartyStats globalMods) =>
        (party.CalcTotalAtk(globalMods) + party.CalcTotalDef() * globalMods.Def) / PARTY_EXPLORATION_TURN_FACTOR; 
}
