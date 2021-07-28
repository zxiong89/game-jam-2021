using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GuildPartyModifierDisplay : GuildPartyModifierDisplayBase
{
    private GuildPartyModifier mod;

    public void DisplayGuildPartyModifier(GuildPartyModifier mod, GuildShopPanel shopPanel)
    {
        this.ShopPanel = shopPanel;
        this.mod = mod;
        SetDisplayBase(mod.Name, mod.Description, mod.Cost, mod.Rental);
    }

    protected override void buyModifier() =>
        ShopPanel?.BuyModifier(mod);

    protected override void rentModifier() =>
        ShopPanel?.RentModifier(mod);
}
