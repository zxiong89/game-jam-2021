using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecruitmentShop : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI bannerText;

    [SerializeField]
    private RecruitmentGrid grid;

    [SerializeField]
    private GameObject PrevButton;

    [SerializeField]
    private GameObject NextButton;

    [SerializeField]
    private UnitFactory testFactory;

    [SerializeField]
    private IntegerLimits[] ageLimits;

    [SerializeField]
    private RecruitmentShopRosters shopRosters;

    [SerializeField]
    private Guild playerGuild;

    private int curPage = 0;

    private void Start()
    {
        LoadPage(0);
        var units = new Unit[4];
        for (int i = 0; i < 4; i++)
        {
            units[i] = testFactory.RandomizeUnit(ageLimits[i]);
        }

        grid.AddToGrid(units);
    }

    public void LoadPage(int pageNumber)
    {
        var units = shopRosters.tierRosters[pageNumber];
        while(units.Count < 4)
        {
            units.Add(testFactory.RandomizeUnit(ageLimits[pageNumber]));
        }
        grid.AddToGrid(units);
        curPage = pageNumber;
    }

    public void BidForUnit(RecruitmentData data)
    {
        if(playerGuild.Gold <= data.Fee)
        {
            //Tell player they don't have enough gold.
        }
        else
        {
            playerGuild.Gold -= data.Fee;
            playerGuild.Roster.Add(data.UnitForHire);
            grid.RemoveUnit(data);
        }
    }
}
