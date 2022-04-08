using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// This script controls the torch on the phone. The torch is on when the conditions in the method 'AccelerationCheck' are met. 
public class WhipEffect : MonoBehaviour
{
    SoundManager sound;
    FlashLightManager FLM;
    float thresh = 5f;
    bool trigger = false;
    private Vector3 accelInfo;
    [SerializeField]
    private ToggleButton toggleAccelButton;
    private bool isOn = false;
    private float waitTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        sound = SoundManager.Instance;
        FLM = FlashLightManager.Instance;
        SensorManager.Instance.OnAcceleration += AccelerationCheck;
        toggleAccelButton.Clicked += OnToggleAccelClicked;
    }

    /// <summary>
    /// Controls the toggle function of the toggle button for controlling the torch with the accelerometer
    /// </summary>
    /// <param name="isOn"></param>
    private void OnToggleAccelClicked(bool isOn)
    {

        this.isOn = isOn;
    }


    /// <summary>
    /// Starts a coroutine that creates a slight delay to turn on the torch
    /// </summary>
    /// <param name="waitTime"></param>
    /// <returns></returns>
    IEnumerator ToggleHold(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        trigger = false;
        yield return new WaitForSeconds(waitTime);
    }

    // Triggers the torch if conditions are met
    void AccelerationCheck(Vector3 vector)
    {
        if (isOn)
        {
            accelInfo = vector;
            if (accelInfo.magnitude > thresh)
            {
                if (!trigger)
                {
                    trigger = true;
                    FLM.ToggleLight();
                    sound.PlaySound();
                    StartCoroutine(ToggleHold(waitTime));
                }
            }
        }
    }
}
