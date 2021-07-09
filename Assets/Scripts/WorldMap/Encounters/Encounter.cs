using UnityEngine;

public abstract class Encounter
{
    protected Encounter()
    {
    }

    public abstract int Run(Party party, int ticks);
    public abstract string LogString();
    public abstract bool IsComplete();

    public abstract float GetExp();
    public abstract float GetGold();
}
