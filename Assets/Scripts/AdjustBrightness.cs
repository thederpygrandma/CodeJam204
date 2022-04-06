using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    private void Start()
    {
        sensorManager = SensorManager.Instance;
        brightnessManager = BrightnessManager.Instance;
        sensorManager.OnAttitude += AdjustSliderBrightness;
        toggleButton.Clicked += OnToggleButtonClicked;
    }

    private void Update()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void OnDisable()
    {
        sensorManager.OnAttitude -= AdjustSliderBrightness;
    }
    

    void OnToggleButtonClicked(bool isOn)
    {
        this.isOn = isOn;
    }
    void AdjustSliderBrightness(Quaternion q)
    {
        debugtxt.text = $"{q.x}, {q.y}, {q.z}";
        if (isOn)
        {
            slider.value = q.x * 2f;
            brightnessManager.SetBrightnessLevel(q.x * 2f);
        }
        else
            brightnessManager.SetBrightnessLevel(slider.value);
    }

}
