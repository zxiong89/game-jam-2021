using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsAndGrowthSwitcher : MonoBehaviour
{
    [SerializeField]
    private UnitDisplay unitDisplay;

    [SerializeField]
    private Button showStatsBtn;

    [SerializeField]
    private Button showGrowthBtn;

    private void Start()
    {
        showStatsBtn.onClick.AddListener(() => ShowStats());
        showGrowthBtn.onClick.AddListener(() => ShowGrowth());
    }

    public void ShowStats()
    {
        activateButtons(false);
    }

    public void ShowGrowth()
    {
        activateButtons(true);
    }

    private void activateButtons(bool showStats)
    {
        showStatsBtn.gameObject.SetActive(showStats);
        showGrowthBtn.gameObject.SetActive(!showStats);
    }
}
