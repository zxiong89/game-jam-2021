public class GuildPartyModifierShopBuyButton : GuildPartyModifierShopButton
{
    protected override string getButtonText(GuildPartyModifier mod) =>
        GuildPartyModifierShopButton.ButtonTextFormat("Buy", mod.Cost);

    protected override bool isInteractable(GuildPartyModifier mod, int? gold) =>
        gold == null ? false : gold.Value >= mod.Cost;
}
