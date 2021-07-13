using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUtility : MonoBehaviour
{
    [SerializeField]
    private UnitClassSelection[] selections;


    private void Start()
    {
        printCommaDelimitedLow();
        printCommaDelimitedAverage();
        printCommaDelimitedHigh();
    }

    private void printCommaDelimitedLow()
    {
        Unit u = new Unit("Test", 1, 19, UnitExtensions.LOW, selections[0].Classes[0], new List<Trait>());
        foreach(var s in selections)
        {
            foreach (var c in s.Classes)
            {
                UnitExtensions.SetUnitClass(u, c);
                UnitExtensions.SimulateLevel1To100(u, $"{c.Name}-Low");
            }
        }
    }

    private void printCommaDelimitedAverage()
    {
        Unit u = new Unit("Test", 1, 19, UnitExtensions.AVERAGE, selections[0].Classes[0], new List<Trait>());
        foreach (var s in selections)
        {
            foreach (var c in s.Classes)
            {
                UnitExtensions.SetUnitClass(u, c);
                UnitExtensions.SimulateLevel1To100(u, $"{c.Name}-Avg");
            }
        }
    }

    private void printCommaDelimitedHigh()
    {
        Unit u = new Unit("Test", 1, 19, UnitExtensions.HIGH, selections[0].Classes[0], new List<Trait>());
        foreach (var s in selections)
        {
            foreach (var c in s.Classes)
            {
                UnitExtensions.SetUnitClass(u, c);
                UnitExtensions.SimulateLevel1To100(u, $"{c.Name}-High");
            }
        }
    }
}
