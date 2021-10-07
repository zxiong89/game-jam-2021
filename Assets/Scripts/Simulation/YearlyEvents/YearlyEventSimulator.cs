using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YearlyEventSimulator
{
    public void UpdateYearlyEvents(YearlyEventQueue events, float currentTime)
    {
        if(events.YearlyEvents.Peek().UpdateTime < currentTime)
        {
            events.YearlyEvents.GetNextAndRepeat(SimulationConstants.SECONDS_PER_YEAR).RunEvent();
        }
    }
}
