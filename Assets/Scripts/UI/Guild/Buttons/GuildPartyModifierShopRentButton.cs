public class GuildPartyModifierShopRentButton : GuildPartyModifierShopButton
{
    protected override string getButtonText(GuildPartyModifier mod) =>
        GuildPartyModifierShopButton.ButtonTextFormat("Rent", mod.Rental);

    protected override bool shouldBeActive(GuildPartyModifier mod, int? gold) =>
        gold == null ? false : gold.Value >= mod.Rental;
}
