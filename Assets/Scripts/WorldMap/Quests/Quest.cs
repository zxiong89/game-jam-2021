using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public const float STARTING_TICKS = 100f;

    public LocationData LocationData { get; private set; }
    public Party Party { get; private set; }
    private Encounter curEncounter;

    public Quest(Party party, LocationData location)
    {
        LocationData = location;
        Party = party;
    }

    public void Adventure(float ticks = STARTING_TICKS)
    {
        if (curEncounter == null) return;
        float remainingTicks = curEncounter.Run(Party, ticks);
        while (remainingTicks > 0) 
        {
            curEncounter = LocationData.SpawnEncounter();
            remainingTicks = curEncounter.Run(Party, remainingTicks);
        }
    }
}
