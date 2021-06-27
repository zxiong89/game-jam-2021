using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI label;

    [SerializeField]
    private TextMeshProUGUI value;

    public void SetLabel(string newLabel)
    {
        label.text = newLabel + ":";
    }

    public void SetValue(string newValue)
    {
        value.text = newValue;
    }
}
