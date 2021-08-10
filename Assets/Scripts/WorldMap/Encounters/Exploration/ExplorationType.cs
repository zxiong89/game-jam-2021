using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "WorldMap/ExplorationType")]
public class ExplorationType : ScriptableObject
{
    public bool IsLair = false;
    public FloatRange Time;
    public IntegerRange Exp;
    public IntegerRange Gold;
}
