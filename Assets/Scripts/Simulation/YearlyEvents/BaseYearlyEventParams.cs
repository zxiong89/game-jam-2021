using UnityEngine;

public abstract class BaseYearlyEventParams : ScriptableObject
{
    [SerializeField]
    protected float calendarTime;

    public abstract BaseYearlyEvent CreateInitialEvent();

    private void OnValidate()
    {
        calendarTime = Mathf.Clamp(calendarTime, 0, 12);
    }
}

public abstract class BaseYearlyEventParams<T> : BaseYearlyEventParams where T : BaseYearlyEvent,new()
{
    public override BaseYearlyEvent CreateInitialEvent()
    {
        return CreateInitialEventHelper();
    }

    public virtual T CreateInitialEventHelper()
    {
        var ev = new T();
        ev.UpdateTime = SimulationConstants.SECONDS_PER_YEAR * calendarTime / 12;
        return ev;
    }

}