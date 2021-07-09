using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "WorldMap/ExplorationType")]
public class ExplorationType : ScriptableObject
{
    public FloatRange Time;
    public FloatRange Exp;
    public FloatRange Gold;
}
