using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "YearlyEvents/YearlyEventQueue")]
public class YearlyEventQueue : ScriptableObject
{
    public MinSortedYearlyEventQueue<BaseYearlyEvent> YearlyEvents { get; private set; } = new MinSortedYearlyEventQueue<BaseYearlyEvent>();

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
