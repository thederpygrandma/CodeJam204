using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class AdjustBrightness : MonoBehaviour
{
    [SerializeField]
    Slider slider;
    [SerializeField]
    TextMeshProUGUI debugtxt;
    SensorManager sensorManager;
    [SerializeField]
    private ToggleButton toggleButton;
    private bool isOn = false;
    BrightnessManager brightnessManager;
    Quaternion referenceRotation;
    float tresh = 0.5f;
    float lightval = 0.007f;

    bool isSet = false;

    private void Start()
    {
        sensorManager = SensorManager.Instance;
        brightnessManager = BrightnessManager.Instance;
        sensorManager.OnAcceleration += AdjustSliderBrightness;
        toggleButton.Clicked += OnToggleButtonClicked;
        Input.compass.enabled = true;
        Input.location.Start();
    }

    private void Update()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void OnDisable()
    {
        sensorManager.OnAcceleration -= AdjustSliderBrightness;
    }
    

    void OnToggleButtonClicked(bool isOn)
    {
        this.isOn = isOn;       
    }
    void AdjustSliderBrightness(Vector3 vec)
    {
        if (isOn)
        {
            debugtxt.text = vec.ToString();
            if (vec.x > tresh)
            {
                slider.value += lightval;
                brightnessManager.SetBrightnessLevel(slider.value);
            } 
            if (vec.x < -0.5)
            {
                slider.value -= lightval;
                brightnessManager.SetBrightnessLevel(slider.value);
            }
        }
    }
}
