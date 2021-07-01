using UnityEngine;

public class PartyStatsGroup : MonoBehaviour
{
    [SerializeField]
    private PartyStatDisplay[] displays;

    public void DisplayPartyStats(PartyStats stats) 
    {
        if (displays == null || displays.Length != 6) return;

        displaySinglePartyStat(displays[0], nameof(stats.Atk), stats.Atk);
        displaySinglePartyStat(displays[1], nameof(stats.Def), stats.Def);
        displaySinglePartyStat(displays[2], nameof(stats.PhyAtk), stats.PhyAtk);
        displaySinglePartyStat(displays[3], nameof(stats.MagAtk), stats.MagAtk);
        displaySinglePartyStat(displays[4], nameof(stats.AtkSup), stats.AtkSup);
        displaySinglePartyStat(displays[5], nameof(stats.DefSup), stats.DefSup);
    }

    private void displaySinglePartyStat(PartyStatDisplay display, string label, float value)
    {
        display.labelValue.SetLabelValue(label, FloatExtensions.ToString(value));
        display.delta.text = "";
    }
}
