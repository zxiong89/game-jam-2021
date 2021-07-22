using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LabelValueDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI label;

    [SerializeField]
    private TextMeshProUGUI value;

    public void SetLabel(string newLabel)
    {
        label.text = newLabel + ":";
    }

    public void SetValue(double newValue) => SetValue(newValue.ToString("f0"));

    public void SetValue(int newValue) => SetValue(newValue.ToString());

    public void SetValue(float newValue) => SetValue(FloatExtensions.ToString(newValue));

    public void SetValue(string newValue)
    {
        value.text = newValue;
    }

    public void SetLabelValue(string newLabel, string newValue)
    {
        SetLabel(newLabel);
        SetValue(newValue);
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
}
