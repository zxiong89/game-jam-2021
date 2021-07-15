using UnityEngine;
using UnityEngine.UI;

public class NotificationIndicator : MonoBehaviour
{
    [SerializeField]
    private Image indicatorImage;

    public void SetVisible(bool isVisible)
    {
        indicatorImage.enabled = isVisible;
    }
}
