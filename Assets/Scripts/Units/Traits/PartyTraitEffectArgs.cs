using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyTraitEffectArgs : BaseTraitEffectArgs
{
    public Unit CurrentUnit { get; set; }
    public Party CurrentParty { get; set; }
}
