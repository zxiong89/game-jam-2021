using System;
using Strings = GenericStrings;

public static class UnitScouting 
{
    public static string ScoutStat(float stat, int scoutingTier)
    {
        float range = getRange(stat, scoutingTier);
        int quotient = (int) Math.Floor(stat / range);
        float lower = quotient * range;

        return $"[ { FloatExtensions.ToString(lower <= 0 ? 1 : lower)} - {FloatExtensions.ToString(lower + range)} ]";
    }

    public static string ScoutSubStat(float subStat, float stat, int scoutingTier)
    {
        if (scoutingTier == 1) return string.Empty;
        return gradeScore(subStat, stat, scoutingTier == 2 ? tier2Grades : tier3Grades);
    }

    private static readonly string[] tier2Grades = { Strings.GradeF, Strings.GradeE, Strings.GradeEPlus, Strings.GradeD, 
        Strings.GradeDPlus, Strings.GradeC, Strings.GradeCPlus, Strings.GradeB, Strings.GradeBPlus, Strings.GradeA };

    private static readonly string[] tier3Grades = { Strings.GradeF, Strings.GradeFPlus, 
        Strings.GradeEMinus, Strings.GradeE, Strings.GradeEPlus, Strings.GradeDMinus, Strings.GradeD, Strings.GradeDPlus,
        Strings.GradeCMinus, Strings.GradeC, Strings.GradeCPlus, Strings.GradeBMinus, Strings.GradeB, Strings.GradeBPlus,
        Strings.GradeAMinus, Strings.GradeA, Strings.GradeAPlus, Strings.GradeSMinus, Strings.GradeS, Strings.GradeSPlus };

    private static string gradeScore(float score, float total, string[] grades)
    {
        int index = score == total ? grades.Length - 1 : 
            (int) Math.Floor((score / total) / (1f / grades.Length));
        return grades[index];
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
