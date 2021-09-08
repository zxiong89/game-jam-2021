using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitContract
{
    public RecruitmentBid Bid
    {
        get;
        private set;
    }

    public static UnitContract CreateContract(Guild playerGuild, RecruitmentBid bid)
    {
        if (playerGuild.Gold < bid.ImmediatePayment()) return null;

        var c = new UnitContract()
        {
            Bid = bid
        };

        return c;
    }
}
