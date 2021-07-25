using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuildPartyModifierDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameDisplay;

    [SerializeField]
    private TextMeshProUGUI descriptionDisplay;

    [SerializeField]
    private BaseButton buyButton;

    [SerializeField]
    private BaseButton rentButton;

    [SerializeField]
    private GuildShopPanel shopPanel;

    private GuildPartyModifier mod
    {
        get => this.mod;
        set
        {
            this.mod = value;
            nameDisplay.text = mod.Name;
            descriptionDisplay.text = mod.Description;
            buyButton.SetText(FormatBuyButton(mod.Cost));
            rentButton.SetText(FormatBuyButton(mod.Rental));
            LayoutRebuilder.ForceRebuildLayoutImmediate(this.GetComponent<RectTransform>());
        }
    }

    public void DisplayGuildPartyModifier(GuildPartyModifier mod, GuildShopPanel shopPanel)
    {
        this.mod = mod;
        this.shopPanel = shopPanel;
    }

    public void BuyModifier()
    {
        shopPanel?.BuyModifier(mod);
    }

    public void RentModifier()
    {
        shopPanel?.RentModifier(mod);
    }

    public static string FormatBuyButton(int cost) =>
        $"Buy ({cost} {GenericStrings.CurrencySymbol})";
    public static string FormatRentalButton(int cost) =>
        $"Rental ({cost} {GenericStrings.CurrencySymbol})";

}
