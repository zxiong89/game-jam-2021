using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public Location Location { get; private set; }
    public Party Party { get; private set; }
    private LocationEvent currentEvent;

    public Quest(Party party, Location location)
    {
        Location = location;
        Party = party;
    }

    public void Adventure() => currentEvent.Run(Party);
}
