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
    Toggle toggleSensors;
    BrightnessManager brightnessManager;

    private void Start()
    {
        sensorManager = SensorManager.Instance;
        brightnessManager = BrightnessManager.Instance;
        sensorManager.OnAttitude += AdjustSliderBrightness;
    }

    private void Update()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void OnDisable()
    {
        sensorManager.OnAttitude -= AdjustSliderBrightness;
    }

    void AdjustSliderBrightness(Quaternion q)
    {
        debugtxt.text = $"{q.x}, {q.y}, {q.z}";
        if (toggleSensors.isOn)
        {
            if (q.z >= 0)
            {
               slider.value = q.z * 2;
               brightnessManager.SetBrightnessLevel(q.z * 2);
            }
        }
        else
            brightnessManager.SetBrightnessLevel(slider.value);
    }

}
