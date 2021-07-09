using TMPro;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI display;

    [SerializeField]
    private int secondsPerYear = 20;

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
        int years =  Mathf.FloorToInt(time / secondsPerYear);
        return years.ToString() + " yr";
    }

    private string DisplayMonths(float time)
    {
        int months = Mathf.FloorToInt((time % secondsPerYear) / secondsPerYear * 12);
        return months + " mo";
    }
}
