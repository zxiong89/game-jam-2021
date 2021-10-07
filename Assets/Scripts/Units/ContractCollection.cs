using UnityEngine;

public class ContractCollection : ScriptableObject
{
    private static MinSortedQueue<ScheduledUnitEvent> activeContracts;

    public static MinSortedQueue<ScheduledUnitEvent> ActiveContracts
    {
        get {
            if (activeContracts == null) activeContracts = new MinSortedQueue<ScheduledUnitEvent>();
            return activeContracts; 
        }
    }
}