﻿public abstract class GuildPartyModifierShopButton : BaseButton
{
    public void SetText(GuildPartyModifier mod, int? gold)
    {
        this.SetText(getButtonText(mod));
        this.Interactable = isInteractable(mod, gold);
    }

    protected abstract string getButtonText(GuildPartyModifier mod);

    protected abstract bool isInteractable(GuildPartyModifier mod, int? gold);

    public static string ButtonTextFormat(string prefix, int cost) =>
        $"{prefix} ({cost} {GenericStrings.CurrencySymbol})";
}
