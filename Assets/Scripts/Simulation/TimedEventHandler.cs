using System.Collections.Generic;

public class TimedEventHandler
{
    public void UpdateTimedEvents(List<TimedEvent> timedEvents)
    {
        List<TimedEvent> completed = new List<TimedEvent>();
        foreach(var e in timedEvents)
        {
            if (e.Execute()) completed.Add(e);
        }

        foreach (var e in completed) timedEvents.Remove(e);
    }
}
