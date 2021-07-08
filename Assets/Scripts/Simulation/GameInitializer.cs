using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Runs any initial game setup
/// </summary>
public class GameInitializer : MonoBehaviour
{
    [SerializeField]
    private Guild playerGuild;

    void Start()
    {
        var unitLocationManager = new UnitLocationManager();

        playerGuild.Initialize();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
