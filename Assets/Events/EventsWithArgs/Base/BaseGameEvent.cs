using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An event that can be emitted and listened for.
/// Define one of these per event argument type.
/// Create a scriptable object from this for each type of event message you wish to send 
/// </summary>
/// <typeparam name="T">The event argument</typeparam>
public abstract class BaseGameEvent<T> : ScriptableObject
{
    /// <summary>
    /// The list of listeners that are active for this event
    /// </summary>
    private readonly List<IGameEventListener<T>> eventListeners = new List<IGameEventListener<T>>();

    /// <summary>
    /// Call this to send out the event
    /// </summary>
    /// <param name="eventArgs">The data for this event</param>
    public void Raise(T eventArgs)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised(eventArgs);
        }
    }

    /// <summary>
    /// Adds a listener to the list of active listeners
    /// Listeners should only be added once. This will log an error if a listener tries to register multiple times.
    /// </summary>
    /// <param name="listener">The listener to add.</param>
    public void RegisterListener(IGameEventListener<T> listener)
    {
        if (eventListeners.Contains(listener)) 
        { 
            Debug.LogError("Attempted to register a listener twice."); 
        }
        else
        {
            eventListeners.Add(listener);
        }
    }

    /// <summary>
    /// Removes a listener from the list of active listeners
    /// Listeners should only be removed once. This will log an error if a listener tries to be removed multiple times.
    /// </summary>
    /// <param name="listener"></param>
    public void UnregisterListener(IGameEventListener<T> listener)
    {
        if (!eventListeners.Contains(listener))
        {
            Debug.LogError("Attempted to unregister an already removed listener.");
        }
        else
        {
            eventListeners.Remove(listener);
        }
    }
    
}
