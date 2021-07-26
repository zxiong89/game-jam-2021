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
    private GuildPartyModifierShopBuyButton buyButton;

    [SerializeField]
    private GuildPartyModifierShopRentButton rentButton;

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
            buyButton.SetText(mod, shopPanel?.PlayerGuild.Gold);
            rentButton.SetText(mod, shopPanel?.PlayerGuild.Gold);
            LayoutRebuilder.ForceRebuildLayoutImmediate(this.GetComponent<RectTransform>());
        }
    }

    public void DisplayGuildPartyModifier(GuildPartyModifier mod, GuildShopPanel shopPanel)
    {
        this.shopPanel = shopPanel;
        this.mod = mod;
    }

    public void BuyModifier()
    {
        shopPanel?.BuyModifier(mod);
    }

    public void RentModifier()
    {
        shopPanel?.RentModifier(mod);
    }


}
