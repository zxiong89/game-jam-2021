using TMPro;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI display;

    //Need to initialize this if we do save/load
    private float currentTime = 0;

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        display.text = DisplayTime(currentTime);
    }

    private string DisplayTime(float time)
    {
        return DisplayYears(time) + " " + DisplayMonths(time);
    }

    private string DisplayYears(float time)
    {
        int years =  Mathf.FloorToInt(time / SimulationConstants.SECONDS_PER_YEAR);
        return years.ToString() + " yr";
    }

    private string DisplayMonths(float time)
    {
        int months = Mathf.FloorToInt((time % SimulationConstants.SECONDS_PER_YEAR) / SimulationConstants.SECONDS_PER_YEAR * 12);
        return months + " mo";
    }
}
