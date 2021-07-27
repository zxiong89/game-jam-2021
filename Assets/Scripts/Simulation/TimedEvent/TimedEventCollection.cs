using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TimedEvents")]
public class TimedEventCollection : ScriptableObject
{
    public List<TimedEvent> timedEvents = new List<TimedEvent>();
}
