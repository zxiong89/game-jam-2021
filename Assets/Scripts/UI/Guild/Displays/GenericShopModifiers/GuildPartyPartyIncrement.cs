using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GuildPartyGenericShopDisplay))]

public class GuildPartyPartyIncrement : MonoBehaviour
{
    [SerializeField]
    private int basePrice;

    [SerializeField]
    private int priceScale;

    [SerializeField]
    private PartyCollection activeParties;

    private GuildPartyGenericShopDisplay display;

    private void Awake()
    {
        display = this.GetComponent<GuildPartyGenericShopDisplay>();
    }

    public void OnInitialize()
    {
        updateDisplayPriceOrDisable();
    }

    public void OnBuy()
    {
        activeParties.NumberAvailable++;
        updateDisplayPriceOrDisable();
    }

    private void updateDisplayPriceOrDisable()
    {
        int numAvailable = activeParties.NumberAvailable;

        if (numAvailable > 0 && numAvailable < activeParties.MaximumAvailable)
        {
            int price = (int)(basePrice * Math.Pow(priceScale, numAvailable));
            display.UpdateCost(price);
        }
        else
        {
            display.gameObject.SetActive(false);
        }
    }
}
