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

    [SerializeField]
    private IntegerVariable unitScoutingTier;

    private void Start()
    {
        if (unitScoutingTier.Value < 2)
        {
            this.gameObject.SetActive(false);
            return;
        }
        showStatsBtn.onClick.AddListener(() => ShowStats());
        showGrowthBtn.onClick.AddListener(() => ShowGrowth());
    }

    public void ShowStats()
    {
        unitDisplay.DisplayStats(true);
        activateButtons(false);
    }

    public void ShowGrowth()
    {
        unitDisplay.DisplayGrowth(true);
        activateButtons(true);
    }

    private void activateButtons(bool showStats)
    {
        showStatsBtn.gameObject.SetActive(showStats);
        showGrowthBtn.gameObject.SetActive(!showStats);
    }
}
