using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextPopup : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textDisplay;

    [SerializeField]
    private RectTransform rectTransform;

    public void SetText(string text)
    {
        textDisplay.text = text;
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
}
