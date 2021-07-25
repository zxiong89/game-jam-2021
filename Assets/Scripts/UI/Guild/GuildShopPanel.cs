using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GuildShopPanel : MonoBehaviour
{
    [SerializeField]
    private GuildPartyModifierCollection activeList;

    [SerializeField]
    private GuildPartyModifierCollection availableList;

    [SerializeField]
    private GameObject prefab;

    private List<GuildPartyModifier> modifiersToBuy;

    private void Start()
    {
        modifiersToBuy = availableList.Modifiers.Where(mod => !activeList.Modifiers.Contains(mod)).ToList();

        foreach (var mod in modifiersToBuy) 
        {

        }
    }

    public void BuyModifier(GuildPartyModifier mod)
    {

    }

    public void RentModifier(GuildPartyModifier mod)
    {

    }
}
