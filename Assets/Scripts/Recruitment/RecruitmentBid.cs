using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct RecruitmentBid
{
    public int GoldPerMonth { get; }
    public int LengthMonthly { get; }
    public int SigningBonus { get; }

    public RecruitmentBid(int goldPerMonth, int months, int signingBonus)
    {
        GoldPerMonth = goldPerMonth;
        LengthMonthly = months;
        SigningBonus = signingBonus;
    }

    public int ImmediatePayment() => SigningBonus + GoldPerMonth;

    public int TotalSalary() => GoldPerMonth * LengthMonthly;

    public int TotalWorth() => SigningBonus + TotalSalary();
}
