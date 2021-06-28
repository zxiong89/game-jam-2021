using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    // The game event instance to register to.
    public GameEvent[] GameEvent;
    // The unity event responce created for the event.
    public UnityEvent Response;

    private void OnEnable()
    {
        foreach(GameEvent ev in GameEvent)
        {
            ev.RegisterListerner(this);
        }
    }

    private void OnDisable()
    {
        foreach (GameEvent ev in GameEvent)
        {
            ev.UnregisterListener(this);
        }
    }

    public void RaiseEvent()
    {
        Response.Invoke();
    }
}
