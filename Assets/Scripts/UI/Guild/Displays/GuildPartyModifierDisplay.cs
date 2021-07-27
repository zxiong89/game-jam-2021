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

    private GuildPartyModifier mod;

    public void DisplayGuildPartyModifier(GuildPartyModifier mod, GuildShopPanel shopPanel)
    {
        this.shopPanel = shopPanel;
        this.mod = mod;
        displayModifier();
    }

    private void displayModifier()
    {
        nameDisplay.text = mod.Name;
        descriptionDisplay.text = mod.Description;
        buyButton.SetText(mod, shopPanel?.PlayerGuild.Gold);
        if (mod.Rental > 0)
        {
            rentButton.gameObject.SetActive(true);
            rentButton.SetText(mod, shopPanel?.PlayerGuild.Gold);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(this.GetComponent<RectTransform>());
    }

    public void BuyModifier()
    {
        shopPanel?.BuyModifier(mod);
        SetAsPurchased();
    }

    public void SetAsPurchased()
    {
        buyButton.SetText(GenericStrings.Purchased);
        buyButton.Interactable = false;
        rentButton.gameObject.SetActive(false);
    }

    public void RentModifier()
    {
        shopPanel?.RentModifier(mod);
        SetAsRented();
    }

    public void SetAsRented()
    {
        rentButton.SetText(GenericStrings.Rented);
        rentButton.Interactable = false;
    }


}
