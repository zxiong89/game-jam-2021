using System;
using UnityEngine;

[RequireComponent(typeof(GuildPartyGenericShopDisplay))]

public abstract class GuildPartyPowScalingModifier : MonoBehaviour
{
    [SerializeField]
    private int basePrice;

    [SerializeField]
    private int priceScale;

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
        onBuy();
        updateDisplayPriceOrDisable();
    }

    protected abstract void onBuy();

    private void updateDisplayPriceOrDisable()
    {
        if (shouldDisableDisplay())
        {
            display.gameObject.SetActive(false);
        }
        else
        {
            double pow = getPower();
            int price = (int)(basePrice * Math.Pow(priceScale, pow < 1 ? 1 : pow));
            display.UpdateCost(price);
        }
    }

    protected abstract bool shouldDisableDisplay();
    protected abstract double getPower();
}
