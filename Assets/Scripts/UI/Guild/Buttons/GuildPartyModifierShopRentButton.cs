public class GuildPartyModifierShopRentButton : GuildPartyModifierShopButton
{
    protected override string getButtonText(int price) =>
        GuildPartyModifierShopButton.ButtonTextFormat("Rent", price);

}
