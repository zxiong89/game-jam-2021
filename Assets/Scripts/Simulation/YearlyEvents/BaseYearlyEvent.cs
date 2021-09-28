public abstract class BaseYearlyEvent  : IScheduleable
{
    public float UpdateTime { get; set; }

    public abstract void RunEvent();
}
