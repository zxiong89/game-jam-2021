using UnityEngine;

public class GuildExpDisplay : MonoBehaviour
{
    [SerializeField]
    private LabelValueDisplay display;

    public void SetValue(float value)
    {
        var max = getMax(value);
        display?.SetValue(max == 0 ? "MAX" : $"{FloatExtensions.ToString(value / max * 100)}%");
    }

    private float getMax(float exp)
    {
        if (exp > GameConstants.GuildLevel10) return 0;
        if (exp > GameConstants.GuildLevel9) return GameConstants.GuildLevel10;
        if (exp > GameConstants.GuildLevel8) return GameConstants.GuildLevel9;
        if (exp > GameConstants.GuildLevel7) return GameConstants.GuildLevel8;
        if (exp > GameConstants.GuildLevel6) return GameConstants.GuildLevel7;
        if (exp > GameConstants.GuildLevel5) return GameConstants.GuildLevel6;
        if (exp > GameConstants.GuildLevel4) return GameConstants.GuildLevel5;
        if (exp > GameConstants.GuildLevel3) return GameConstants.GuildLevel4;
        if (exp > GameConstants.GuildLevel2) return GameConstants.GuildLevel3;
        return GameConstants.GuildLevel2;
    }
}
