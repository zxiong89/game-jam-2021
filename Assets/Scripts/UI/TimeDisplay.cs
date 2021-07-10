using TMPro;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI display;

    [SerializeField]
    private int secondsPerYear = 20;

    [SerializeField]
    private FloatVariable currentTime;

    private void Start()
    {
    }

    private void Update()
    {
        currentTime.Value += Time.deltaTime;
        display.text = DisplayTime(currentTime.Value);
    }

    private string DisplayTime(float time)
    {
        return DisplayYears(time) + " " + DisplayMonths(time);
    }

    private string DisplayYears(float time)
    {
        int years =  Mathf.FloorToInt(time / secondsPerYear);
        return years.ToString() + " yr";
    }

    private string DisplayMonths(float time)
    {
        int months = Mathf.FloorToInt((time % secondsPerYear) / secondsPerYear * 12);
        return months + " mo";
    }
}
