using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Listens for the event supplied in GameEvent. WHen the event is raised, this will call any methods listed in the response
/// Define one of these per type of event arguments
/// Attack this to any objects that will listen for an event.
/// </summary>
/// <typeparam name="T">The type of the event argument</typeparam>
/// <typeparam name="E">The base type of the event to listen for</typeparam>
/// <typeparam name="UER">The unity event class that can deal with the event argument</typeparam>
public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour,
    IGameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T>
{
    /// <summary>
    /// The event this listener will listen for
    /// </summary>
    [SerializeField]
    private E[] gameEvents;
    public E[] GameEvents
    {
        get { return gameEvents; }
        set { gameEvents = value; }
    }
    
    /// <summary>
    /// The methods that will be called when the event occurs
    /// </summary>
    [SerializeField] private UER unityEventResponse;

    private void OnEnable()
    {
        foreach(var ev in gameEvents){
            ev.RegisterListener(this);
        }
    }

    private void OnDisable()
    {
        foreach (var ev in gameEvents)
        {
            ev.UnregisterListener(this);
        }
    }

    public void OnEventRaised(T eventArgs)
    {
        unityEventResponse.Invoke(eventArgs);
    }
}