using UnityEngine;
using UnityEngine.UI;

public class GameSpeedController : MonoBehaviour
{
    [SerializeField]
    private FloatEvent gameSpeedEvent;

    [SerializeField]
    private Image[] speedButtonImages;

    [SerializeField]
    private int[] speedButtonSpeeds;

    public void SetGameSpeed(int buttonIndex)
    {
        UpdateButtonColors(buttonIndex);
        gameSpeedEvent.Raise(speedButtonSpeeds[buttonIndex]);
    }

    private void UpdateButtonColors(int buttonIndex)
    {
        for (int i = 0; i < speedButtonImages.Length; i++)
        {
            var buttonColor = speedButtonImages[i].color;
            buttonColor.a = (i == buttonIndex) ? 1f : .5f;
            speedButtonImages[i].color = buttonColor;
        }
    }
}
