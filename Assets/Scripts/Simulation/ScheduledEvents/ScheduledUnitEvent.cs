public class ScheduledUnitEvent : IScheduleable
{

    public Unit Unit { get; }

    private float updateTime;
    public float UpdateTime { get => updateTime; set => updateTime = value; }
    
    public ScheduledUnitEvent(Unit newUnit, float newUpdateTime)
    {
        Unit = newUnit;
        updateTime = newUpdateTime;
    }
}
