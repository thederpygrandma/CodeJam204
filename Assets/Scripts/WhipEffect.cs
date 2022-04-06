using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhipEffect : MonoBehaviour
{
    [SerializeField]
    Toggle toggleWhip;
    float thresh = 2f;
    bool trigger = false;
    private Vector3 accelInfo;
    public TMPro.TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        SensorManager.Instance.OnAcceleration += Whatever;
    }

    private void Update()
    {
        if (text)
            text.text = "Acceleration " + accelInfo.magnitude.ToString();
    }

    void Whatever(Vector3 vector)
    {
        if (toggleWhip.isOn)
        {
            accelInfo = vector;
            if (accelInfo.magnitude > thresh)
            {
                if (!trigger)
                {
                    trigger = true;
                    Debug.Log("test");
                }
            }
            else if (trigger)
            {
                trigger = false;
            }
        }
    }
}