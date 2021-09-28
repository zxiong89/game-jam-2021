using System;
using TMPro;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI display;

    [SerializeField]
    private FloatVariable currentTime;

    [SerializeField]
    private RadialProgressBar monthProgressDisplay;

    private void Update()
    {
        (int years, int months, float monthsProgress) = CalculateTime(currentTime.Value);       
        display.text = DisplayTime(years, months);
        monthProgressDisplay.SetProgress(monthsProgress);
    }

    private (int, int, float) CalculateTime(float time)
    {
        int years = Mathf.FloorToInt(time / SimulationConstants.SECONDS_PER_YEAR);
        float fullMonths = (time - (years * SimulationConstants.SECONDS_PER_YEAR)) / SimulationConstants.SECONDS_PER_YEAR * 12;
        int monthsComplete = Mathf.FloorToInt(fullMonths);
        float monthsProgress = fullMonths - monthsComplete;   

        return (years, monthsComplete, monthsProgress);
    }

    private string DisplayTime(float years, float months)
    {
        return DisplayYears(years) + " " + DisplayMonths(months);
    }

    private string DisplayYears(float years)
    {
        return years.ToString() + " yr";
    }

    private string DisplayMonths(float months)
    {
        return months + " mo";
    }
}
