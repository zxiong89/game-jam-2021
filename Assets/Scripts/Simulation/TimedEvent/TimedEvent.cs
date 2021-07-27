using System;
using UnityEngine;

public class TimedEvent
{
    /// <summary>
    /// Time since last simulator update
    /// </summary>
    private float timeToGo = SimulationConstants.SECONDS_PER_YEAR;

    private Action callback;

    public TimedEvent(Action callback) 
    {
        this.callback = callback;
    }

    public TimedEvent(Action callback, float years) : this(callback)
    {
        timeToGo = SimulationConstants.SECONDS_PER_YEAR * years;
    }

    /// <summary>
    /// Attempts to execute the timed event. False if the event is still counting
    /// </summary>
    /// <returns>True if the event was executed, false otherwise.</returns>
    public bool Execute()
    {
        timeToGo -= Time.deltaTime;
        if (timeToGo <= 0)
        {
            callback();
            return true;
        }
        return false;
    }
}
