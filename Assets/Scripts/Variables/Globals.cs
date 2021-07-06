using UnityEngine;

/// <summary>
/// Holds objects that should only be set up once. Break this up as need be
/// </summary>
public class Globals : MonoBehaviour
{
    [SerializeField]
    private UnitFactory unitFactory;
    public UnitFactory UnitFactory
    {
        get { return unitFactory; }
    }
}
