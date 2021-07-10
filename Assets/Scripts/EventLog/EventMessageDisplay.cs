using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventMessageDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI messageText;

    [SerializeField]
    private Image backgroundImage;
    public void DisplayMessage(string message, bool isAlternateRow)
    {
        messageText.text = message;
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
        if (isAlternateRow)
        {
            backgroundImage.color = new Color(0f, .09f, .27f);
        }
    }
}

