using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoordinatesText : MonoBehaviour
{
    public TextMeshProUGUI coordinates;
    public TextMeshProUGUI savedCoordinates;

    // displays the current coordinates on the screen
    private void Update()
    {
        coordinates.text = "Latitude:" + GPSManager.Instance.latitude.ToString() + "   Longitude:" + GPSManager.Instance.longitude.ToString();

        savedCoordinates.text = "Latitude:" + GPSManager.Instance.savedLatitude.ToString() + "   Longitude:" + GPSManager.Instance.savedLongitude.ToString();
    }
}
