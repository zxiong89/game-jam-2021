using UnityEngine;

public class PartySelectionDisplay : MonoBehaviour
{
    [SerializeField]
    private PartyData partyData;

    [SerializeField]
    private Guild guild;

    [SerializeField]
    private PartyUnitSelection[] unitDisplays;

    public Party Party 
    {
        get => partyData.Party;
        set
        {
            partyData.Party = value;
            for(var i = 0; i < unitDisplays.Length; i++)
            {
                if (unitDisplays[i] == null) return; 

                if (partyData.Party == null) unitDisplays[i].Unit = null;
                else 
                {
                    var line = i < PartyLine.MAX_SIZE ? 
                        partyData.Party.FrontLine 
                        : 
                        partyData.Party.BackLine;

                    unitDisplays[i].Unit = line == null || i >= line.Count ? null : line[i % PartyLine.MAX_SIZE];
                }
            }
        }
    }

    public void CopyAndSetParty(PartyEventArgs args)
    {
        Party = new Party(args.Party);
    }

    public void SetParty(PartyEventArgs args)
    {
        Party = args.Party;
    }
}
