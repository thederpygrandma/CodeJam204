using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    FlashLightManager FLM;
    GPSManager GPS;

    private void Update()
    {
        LocationChecker();
    }

    // måske bruge switch? men ville jeg så ik sku bruge en switch for både latitude?
    private void LocationChecker()
    {
        if (GPS.latitude > GPS.savedLatitude)
        {
            FLM.FL_Start();
        }
        else if (GPS.latitude < GPS.savedLatitude)
        {
            FLM.FL_Start();
        }
        else if (GPS.longitude > GPS.savedLongitude)
        {
            FLM.FL_Start();
        }
        else if (GPS.longitude < GPS.savedLongitude)
        {
            FLM.FL_Start();
        }
        else
        {
            FLM.FL_Stop();
        }
    }
        
}
