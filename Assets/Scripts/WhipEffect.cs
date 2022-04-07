using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhipEffect : MonoBehaviour
{
    private float[] _sensorValues = new float[4];
    SoundManager sound;
    FlashLightManager FLM;
    float thresh;
    bool trigger = false;
    private Vector3 accelInfo;
    public TMPro.TMP_Text text;
    [SerializeField]
    private ToggleButton toggleAccelButton;
    private bool isOn = false;
    private float waitTime = 1f;
    SensorManager sensorManager;
    bool isDoingShit = false;

    // Start is called before the first frame update
    void Start()
    {
        sensorManager = SensorManager.Instance;
        sound = SoundManager.Instance;
        FLM = FlashLightManager.Instance;
        sensorManager.OnAcceleration += Whatever;
        toggleAccelButton.Clicked += OnToggleAccelClicked;
    }

    private void OnToggleAccelClicked(bool isOn)
    {
        this.isOn = isOn;
    }

    IEnumerator ToggleHold(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        trigger = false;
        yield return new WaitForSeconds(waitTime);
    }
    void Whatever(Vector3 vector)
    {
        _sensorValues[3] = vector.magnitude;
        _sensorValues[2] = _sensorValues[3];
        _sensorValues[1] = _sensorValues[2];
        _sensorValues[0] = _sensorValues[1];

        if (isOn)
        {

            thresh = (_sensorValues[3] + _sensorValues[2] + _sensorValues[1] + _sensorValues[0]) / _sensorValues.Length;

            text.text = accelInfo.magnitude.ToString();
            accelInfo = vector;

            if (accelInfo.magnitude > 3f)
            {
                Debug.Log("Threashold reached");
                if (!trigger)
                {
                    trigger = true;
                    Debug.Log("test");
                    FLM.ToggleLight();
                    sound.PlaySound();

                    //StartCoroutine(ToggleHold(waitTime));
                }
            }
            else if (trigger)
            {
                trigger = false;
            }
        }
    }
}