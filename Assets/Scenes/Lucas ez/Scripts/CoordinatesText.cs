using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoordinatesText : MonoBehaviour
{
    public TextMeshProUGUI coordinates;

    private void Update()
    {
        coordinates.text = "Latitude:" + GPSManager.Instance.latitude.ToString() + "   Longitude:" + GPSManager.Instance.longitude.ToString();
    }
}
