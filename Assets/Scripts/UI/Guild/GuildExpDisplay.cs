using UnityEngine;

public class GuildExpDisplay : MonoBehaviour
{
    [SerializeField]
    private LabelValueDisplay display;

    public void SetValue(float value)
    {
        var max = getMax(value);
        if (max == 0) 
        display?.SetValue(max == 0 ? "MAX" : $"{FloatExtensions.ToString(value / max * 100)}%");
    }

    private float getMax(float exp)
    {
        if (exp > FloatConstants.GuildLevel10) return 0;
        if (exp > FloatConstants.GuildLevel9) return FloatConstants.GuildLevel10;
        if (exp > FloatConstants.GuildLevel8) return FloatConstants.GuildLevel9;
        if (exp > FloatConstants.GuildLevel7) return FloatConstants.GuildLevel8;
        if (exp > FloatConstants.GuildLevel6) return FloatConstants.GuildLevel7;
        if (exp > FloatConstants.GuildLevel5) return FloatConstants.GuildLevel6;
        if (exp > FloatConstants.GuildLevel4) return FloatConstants.GuildLevel5;
        if (exp > FloatConstants.GuildLevel3) return FloatConstants.GuildLevel4;
        if (exp > FloatConstants.GuildLevel2) return FloatConstants.GuildLevel3;
        return FloatConstants.GuildLevel2;
    }
}
