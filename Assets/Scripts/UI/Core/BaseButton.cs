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

    public bool Interactable
    {
        get => buttonComponent.interactable;
        set => buttonComponent.interactable = value;
    }

    public void SetText(string newText)
    {
        buttonText.text = newText;
    }

    public void SetSize(Vector2 newSize)
    {
        buttonComponent.GetComponent<RectTransform>().sizeDelta = newSize;
    }

    public void SetCallback(Action callback)
    {
        buttonComponent.onClick.AddListener(() => callback.Invoke());
    }
}
