using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitShopNotificationIndicator : NotificationIndicator
{
    [SerializeField]
    public RecruitmentShopRosters shopRosters;

    private void OnEnable()
    {
        shopRosters.ShopHasNewUnits += SetVisible;
    }

    private void OnDisable()
    {
        shopRosters.ShopHasNewUnits -= SetVisible;
    }
}
