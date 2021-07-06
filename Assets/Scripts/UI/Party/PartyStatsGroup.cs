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

    private void displaySinglePartyStat(PartyStatDisplay display, string label, float value, float? deltaVal = null)
    {
        display.labelValue.SetLabelValue(label, FloatExtensions.ToString(value));
        displaySinglePartyStatDelta(display, deltaVal);
    }

    public void DisplayPartyStatsDelta(PartyStats stats)
    {
        if (displays == null || displays.Length != 6) return;

        displaySinglePartyStatDelta(displays[0], stats.Atk);
        displaySinglePartyStatDelta(displays[1], stats.Def);
        displaySinglePartyStatDelta(displays[2], stats.PhyAtk);
        displaySinglePartyStatDelta(displays[3], stats.MagAtk);
        displaySinglePartyStatDelta(displays[4], stats.AtkSup);
        displaySinglePartyStatDelta(displays[5], stats.DefSup);
    }

    private void displaySinglePartyStatDelta(PartyStatDisplay display, float? deltaVal)
    {
        if (display.delta == null) return;

        if (deltaVal == null) display.delta.text = "";
        else
        {
            display.delta.text = string.Format("({0})",FloatExtensions.ToString(deltaVal.Value));
            display.delta.color = deltaVal < 0 ? Color.red : Color.green;
        }
    }
}
