using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class to make it easier to manipulate buttons
/// </summary>
public class BaseButton : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI buttonText;

    [SerializeField]
    private Button buttonComponent;

    public void SetText(string newText)
    {
        buttonText.text = newText;  
    }

    public void SetCallback(Action callback)
    {
        buttonComponent.onClick.AddListener(() => callback.Invoke());
    }
}
