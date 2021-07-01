using UnityEngine;

public class PartySelectionDisplay : MonoBehaviour
{
    [SerializeField]
    private PartyUnitSelection[] unitDisplays;

    private Party party;
    public Party Party 
    {
        get => party;
        set
        {
            party = value;
            for(var i = 0; i < unitDisplays.Length; i++)
            {
                if (unitDisplays[i] == null) return; 

                if (party == null) unitDisplays[i].Unit = null;
                else 
                {
                    var line = i < PartyLine.MAX_SIZE ? party.FrontLine : party.BackLine;
                    unitDisplays[i].Unit = line[i % PartyLine.MAX_SIZE];
                }
            }
        }
    }
}
