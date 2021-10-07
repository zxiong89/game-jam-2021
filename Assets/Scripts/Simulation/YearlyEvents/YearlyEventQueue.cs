using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "YearlyEvents/YearlyEventQueue")]
public class YearlyEventQueue : ScriptableObject
{
    public MinSortedQueue<BaseYearlyEvent> YearlyEvents { get; private set; } = new MinSortedQueue<BaseYearlyEvent>();

    [SerializeField]
    private List<BaseYearlyEventParams> startingYearlyEvents = new List<BaseYearlyEventParams>();

    public void Reset()
    {
        foreach (var ev in startingYearlyEvents)
        {
            YearlyEvents.Add(ev.CreateInitialEvent());
        }
    }
}
