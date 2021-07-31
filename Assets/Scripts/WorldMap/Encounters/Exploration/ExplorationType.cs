using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "WorldMap/ExplorationType")]
public class ExplorationType : ScriptableObject
{
    public bool IsSpecial = false;
    public FloatRange Time;
    public IntegerRange Exp;
    public IntegerRange Gold;
}
