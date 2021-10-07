using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitContract
{
    public static UnitContract CreateContract(Guild playerGuild, int goldPerMonth, int months, int signingBonus, float currentTime)
    {
        if (playerGuild.Gold < CalcImmediatePayment(goldPerMonth, signingBonus)) return null;

        var c = new UnitContract(goldPerMonth, months, signingBonus, currentTime);

        return c;
    }

    public int GoldPerMonth { get; private set; }
    public int LengthMonthly { get; private set; }
    public int SigningBonus { get; private set; }


    private UnitContract(int goldPerMonth, int months, int signingBonus, float currentTime)
    {
        GoldPerMonth = goldPerMonth;
        LengthMonthly = months;
        SigningBonus = signingBonus;

        ImmediatePayment = CalcImmediatePayment(goldPerMonth, signingBonus);
        TotalSalary = goldPerMonth * months;
        TotalWorth = signingBonus + TotalSalary;
        EndTime = currentTime + (SimulationConstants.SECONDS_PER_YEAR / 12 * months);
    }

    private static int CalcImmediatePayment(int goldPerMonth, int signingBonus) =>
        goldPerMonth + signingBonus;

    public int ImmediatePayment { get; private set; }

    public int TotalSalary { get; private set; }

    public int TotalWorth { get; private set; }

    public float EndTime { get; private set; }
}
