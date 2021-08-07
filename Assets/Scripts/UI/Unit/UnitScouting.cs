using System;

public static class UnitScouting 
{
    public static string ScoutStat(float stat, int scoutingTier)
    {
        float range = getRange(stat, scoutingTier);
        int quotient = (int) Math.Floor(stat / range);
        float lower = quotient * range;

        return $"[ {FloatExtensions.ToString(lower + 1)} - {FloatExtensions.ToString(lower + range)} ]";
    }

    public static string ScoutSubStat(float growthGrade, int scoutingTier)
    {
        return "";
    }

    private static float getRange(float stat, int scoutingTier)
    {
        float baseRange = 0f;
        float multiplier = scoutingTier == 1 ? 3 : scoutingTier == 2 ? 2 : 1;

        if (stat < 100)
        {
            if (multiplier == 1) return 1;
            if (multiplier == 2) return 5;
            return 10;
        }
        else if (stat < 1000)
        {
            baseRange = 5;
        }
        else if (stat < 10000)
        {
            baseRange = 25;
        }
        else if (stat < 100000)
        {
            baseRange = 125;
        }

        return baseRange * multiplier;
    }
}
