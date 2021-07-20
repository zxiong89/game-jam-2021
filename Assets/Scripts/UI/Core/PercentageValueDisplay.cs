using UnityEngine;

public class PercentageValueDisplay : MonoBehaviour
{
    [SerializeField]
    private LabelValueDisplay display;

    private float value;
    public float Value
    {
        get => value;
        set
        {
            this.value = value;
            display?.SetValue(calcPercentage());
        }
    }

    private float max;
    public float Max
    {
        get => max;
        set
        {
            max = value;
            display?.SetValue(calcPercentage());
        }
    }

    private float calcPercentage() => value / max * 100;
}
