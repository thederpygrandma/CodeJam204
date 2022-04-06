using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhipEffect : MonoBehaviour
{
    float thresh = 2f;
    bool trigger = false;
    private Vector3 accelInfo;
    public TMPro.TMP_Text text;
    [SerializeField]
    private ToggleButton toggleAccelButton;
    private bool isOn = false;

    // Start is called before the first frame update
    void Start()
    {
        SensorManager.Instance.OnAcceleration += Whatever;
        toggleAccelButton.Clicked += OnToggleAccelClicked;
    }

    private void OnToggleAccelClicked(bool isOn)
    {

        this.isOn = isOn;
    }
    void Whatever(Vector3 vector)
    {
        if (isOn)
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
        } else
        {

        }
    }
}