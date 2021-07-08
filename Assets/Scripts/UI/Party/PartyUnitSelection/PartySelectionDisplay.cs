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
                    var index = i % PartyLine.MAX_SIZE;
                    unitDisplays[i].Unit = line == null || index >= line.Count ? null : line[index];
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
