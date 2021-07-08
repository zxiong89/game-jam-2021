using UnityEngine;

public class GameSpeedController : MonoBehaviour
{
    [SerializeField]
    private FloatEvent gameSpeedEvent;

    public void SetGameSpeed(float speed)
    {
        gameSpeedEvent.Raise(speed);
    }
}
