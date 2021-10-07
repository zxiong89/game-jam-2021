using System;
using System.Collections.Generic;

/// <summary>
/// Sorted queue for events
/// Optimized for insertion to start and end of queue.
/// </summary>
/// <typeparam name="T">The type of object in the queue</typeparam>
public class MinSortedQueue<T> where T : class,IScheduleable
{
    private LinkedList<T> queue = new LinkedList<T>();

    public void Add(T scheduleable)
    {
        LinkedListNode<T> node = queue.First;
        if (queue.Count == 0 || scheduleable.UpdateTime < node?.Value.UpdateTime)
        {
            queue.AddFirst(scheduleable);
        }
        else
        {
            while (scheduleable.UpdateTime > node.Next?.Value.UpdateTime)
            {
                node = node.Next;
            }
            queue.AddAfter(node, scheduleable);
        }
    }

    public void Remove(T schedulable)
    {
        queue.Remove(schedulable);
    }

    public void Remove(Func<T, bool> predicate)
    {
        LinkedListNode<T> curNode = queue.First;
        while(curNode != null && !predicate(curNode.Value))
        {
            curNode = curNode.Next;
        }
        if (curNode != null) queue.Remove(curNode);
    }

    public T Peek()
    {
        if (queue.Count == 0) return null;
        return queue.First.Value;
    }

    public T GetNext()
    {
        T nextValue = queue.First?.Value;
        queue.RemoveFirst();
        return nextValue;
    }

    public T GetNextAndRepeat(float repeatTime)
    {
        if (queue.Count == 0) return null;

        T nextNode = queue.First.Value;
        queue.RemoveFirst();
        nextNode.UpdateTime += repeatTime;
        if(nextNode.UpdateTime >= queue.Last?.Value.UpdateTime)
        {
            queue.AddLast(nextNode);
        }
        else
        {
            Add(nextNode);
        }
        return nextNode;
    }

    public void Clear()
    {
        queue.Clear();
    }
}
