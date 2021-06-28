using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An interface for the functionality an event listener must implement
/// You shouldn't need to add this to anything.
/// </summary>
/// <typeparam name="T">The event argument the event will carry</typeparam>
public interface IGameEventListener<T>
{
    /// <summary>
    /// Called when the event is raised
    /// </summary>
    /// <param name="eventArgs">Event arguments carrying the relevant data to the event</param>
    void OnEventRaised(T eventArgs);
}
