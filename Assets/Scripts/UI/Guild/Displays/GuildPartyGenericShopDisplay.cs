using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GuildPartyGenericShopDisplay : GuildPartyModifierDisplayBase
{
    [Header("Generic Initial Fields")]
    [SerializeField]
    private string Name;

    [SerializeField]
    [TextArea]
    private string description;

    [SerializeField]
    private int cost;

    [Header("Callbacks")]
    [SerializeField]
    private UnityEvent onInit;

    [SerializeField]
    private UnityEvent onBuy;

    public void Start()
    {
        SetDisplayBase(Name, description, cost);
        onInit?.Invoke();
    }

    public void UpdateCost(int cost)
    {
        BuyButton.SetText(cost, ShopPanel?.PlayerGuild.Gold);
        LayoutRebuilder.ForceRebuildLayoutImmediate(this.GetComponent<RectTransform>());
    }

    protected override void buyModifier()
    {
        onBuy?.Invoke();
    }

    protected override void rentModifier()
    {
    }
}
