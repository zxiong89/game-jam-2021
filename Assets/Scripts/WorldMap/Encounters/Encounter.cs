using UnityEngine;

public abstract class Encounter
{
    protected Encounter()
    {
    }

    public abstract EncounterResults Run(Party party, int turns);
    public abstract string LogString();

    public abstract bool IsComplete();
}
