using System.Collections.Generic;
using UnityEngine;

public class UnitCollection
{
    private static MinSortedQueue<ScheduledUnitEvent> activeUnits;

    public static MinSortedQueue<ScheduledUnitEvent> ActiveUnits
    {
        get {
            if (activeUnits == null) activeUnits = new MinSortedQueue<ScheduledUnitEvent>();
            return activeUnits; 
        }
    }

}