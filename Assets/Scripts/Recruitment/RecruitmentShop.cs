using TMPro;
using UnityEngine;

public class RecruitmentShop : MonoBehaviour, IMainDisplay
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
    private Guild playerGuild;

    [SerializeField]
    private GameObject unitDetailsPopup;

    [SerializeField]
    private PopupEvent showPopup;

    private int curPage = 0;

    private void Start()
    {
        LoadPage(0);
    }

    public void LoadPage(int pageNumber)
    {
        AdventurerTier tier = AdventurerTierHelpers.Convert(pageNumber);
        grid.LoadRoster(tier);
        UpdateBanner(tier);
        UpdatePageButtons();
    }

    public void ChangePage(int difference)
    {
        curPage += difference;
        LoadPage(curPage);
    }

    private void UpdateBanner(AdventurerTier tier)
    {
        bannerText.text = tier.ToString() + " Adventurers";
    }

    private void UpdatePageButtons()
    {
        PrevButton.gameObject.SetActive(curPage > 0);
        NextButton.gameObject.SetActive(curPage < 3);
    }

    public void BidForUnit(RecruitmentData data)
    {
        var unitDetails = Instantiate(unitDetailsPopup);
        unitDetails.GetComponentInChildren<UnitDisplay>().DisplayUnit(data.UnitForHire);

        var popupArgs = new PopupEventArgs()
        {
            Content = unitDetails,
            AcceptTextOverride = "Hire",
            AcceptCallback = (gameObject) =>
            {
                TryHireUnit(gameObject, data);
            }
        };
        showPopup.Raise(popupArgs);

        var unitDetails2 = Instantiate(unitDetailsPopup);
        unitDetails2.GetComponentInChildren<UnitDisplay>().DisplayUnit(data.UnitForHire);
        var popupArgs2 = new PopupEventArgs()
        {
            Content = unitDetails2,
            AcceptTextOverride = "Hire",
            AcceptCallback = (gameObject) =>
            {
                TryHireUnit(gameObject, data);
            }
        };
        showPopup.Raise(popupArgs2);
    }

    private void TryHireUnit(GameObject hirePopup, RecruitmentData data)
    {
        if(playerGuild.Gold < data.Fee)
        {
            var popupArgs = new PopupEventArgs()
            {
                Text = "You don't have enough gold!",
            };
            showPopup.Raise(popupArgs);
        }
        else
        {
            playerGuild.Gold -= data.Fee;
            playerGuild.Roster.Add(data.UnitForHire);
            grid.RefreshGridDisplay();
        }
    }

    public void LoadGlobals(Globals globals)
    {
        grid.Initialize(globals.UnitFactory);
    }
}
