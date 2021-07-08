using UnityEngine;

public abstract class Encounter
{
    protected Encounter()
    {
    }

    public abstract float Run(Party party, float ticks);
    public abstract string Name();
    public abstract float Completion();
}
