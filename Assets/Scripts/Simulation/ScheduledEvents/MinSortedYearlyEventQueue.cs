using System.Collections.Generic;

/// <summary>
/// Sorted queue for events repeated every year.
/// Optimized for insertion to start and end of queue.
/// </summary>
/// <typeparam name="T">The type of object in the queue</typeparam>
public class MinSortedYearlyEventQueue<T> where T : class,IScheduleable
{
    private LinkedList<T> newCurUnits = new LinkedList<T>();

    public void Add(T unitToAdd)
    {
        LinkedListNode<T> unitNode = newCurUnits.First;
        if (newCurUnits.Count == 0 || unitToAdd.UpdateTime < unitNode?.Value.UpdateTime)
        {
            newCurUnits.AddFirst(unitToAdd);
        }
        else
        {
            while (unitToAdd.UpdateTime > unitNode.Next?.Value.UpdateTime)
            {
                unitNode = unitNode.Next;
            }
            newCurUnits.AddAfter(unitNode, unitToAdd);
        }
    }

    public void Remove(T unitToRemove)
    {
        newCurUnits.Remove(unitToRemove);
    }

    public T Peek()
    {
        if (newCurUnits.Count == 0) return null;
        return newCurUnits.First.Value;
    }

    public T GetNext()
    {
        return newCurUnits.First?.Value;
    }

    /// <summary>
    /// Gets the next value, then adds it back to the queue a year later
    /// </summary>
    /// <returns>The next value in the queue</returns>
    public T GetNextAndRepeat()
    {
        if (newCurUnits.Count == 0) return null;

        T nextUnit = newCurUnits.First.Value;
        newCurUnits.RemoveFirst();
        nextUnit.UpdateTime += SimulationConstants.SECONDS_PER_YEAR;
        if(nextUnit.UpdateTime >= newCurUnits.Last?.Value.UpdateTime)
        {
            newCurUnits.AddLast(nextUnit);
        }
        else
        {
            Add(nextUnit);
        }
        return nextUnit;
    }
}
