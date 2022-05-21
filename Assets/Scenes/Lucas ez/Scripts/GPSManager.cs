using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSManager : SingletonPattern<GPSManager>
{
    public float latitude;
    public float longitude;
    public float savedLatitude;
    public float savedLongitude;
    private int maxWait = 20;
    IEnumerator coroutine;

    private IEnumerator Start()
    {
        coroutine = UpdateLocation();

        if (!Input.location.isEnabledByUser)
            yield break;

        Input.location.Start();

        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }

        savedLatitude = Input.location.lastData.latitude;
        savedLongitude = Input.location.lastData.longitude;

        Debug.Log(savedLatitude);
        Debug.Log(savedLongitude);

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        StartCoroutine(coroutine);
    }

    IEnumerator UpdateLocation()
    {
        float updateWaitTime = 2f; //Every  3 seconds
        WaitForSeconds updateTime = new WaitForSeconds(updateWaitTime);

        while (true)
        {
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            yield return updateTime;
        }

        void StopGPS()
        {
            Input.location.Stop();
            StopCoroutine(coroutine);
        }

        void OnDisable()
        {
            StopGPS();
        }

    }

    
}
