public abstract class GuildPartyModifierShopButton : BaseButton
{
    public void SetText(int price, int? gold)
    {
        this.SetText(getButtonText(price));
        this.Interactable = isInteractable(price, gold);
    }

    protected abstract string getButtonText(int price);

    protected virtual bool isInteractable(int price, int? gold) =>
        gold == null ? false : gold.Value >= price;

    public static string ButtonTextFormat(string prefix, int cost) =>
        $"{prefix} ({cost} {GenericStrings.CurrencySymbol})";
}
