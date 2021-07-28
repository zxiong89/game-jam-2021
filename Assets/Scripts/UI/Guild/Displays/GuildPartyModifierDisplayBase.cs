using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class GuildPartyModifierDisplayBase : MonoBehaviour
{
    [Header("Displays")]
    [SerializeField]
    protected TextMeshProUGUI NameDisplay;

    [SerializeField]
    protected TextMeshProUGUI DescriptionDisplay;

    [SerializeField]
    protected GuildPartyModifierShopBuyButton BuyButton;

    [SerializeField]
    protected GuildPartyModifierShopRentButton RentButton;

    [SerializeField]
    protected GuildShopPanel ShopPanel;

    protected void SetDisplayBase(
        string modName, string modDesc, int buyPrice, int rentPrice = 0)
    {
        NameDisplay.text = modName;
        DescriptionDisplay.text = modDesc;
        BuyButton.SetText(buyPrice, ShopPanel?.PlayerGuild.Gold);
        if (rentPrice > 0)
        {
            RentButton.gameObject.SetActive(true);
            RentButton.SetText(rentPrice, ShopPanel?.PlayerGuild.Gold);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(this.GetComponent<RectTransform>());
    }

    public void BuyModifier()
    {
        buyModifier();
        SetAsPurchased();
    }

    protected abstract void buyModifier();

    public void SetAsPurchased()
    {
        BuyButton.SetText(GenericStrings.Purchased);
        BuyButton.Interactable = false;
        RentButton.gameObject.SetActive(false);
    }

    public void RentModifier()
    {
        rentModifier();
        SetAsRented();
    }

    protected abstract void rentModifier();

    public void SetAsRented()
    {
        RentButton.SetText(GenericStrings.Rented);
        RentButton.Interactable = false;
    }
}
