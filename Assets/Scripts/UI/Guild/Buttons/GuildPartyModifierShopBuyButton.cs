public class GuildPartyModifierShopBuyButton : GuildPartyModifierShopButton
{
    protected override string getButtonText(int price) =>
        GuildPartyModifierShopButton.ButtonTextFormat("Buy", price);
}
