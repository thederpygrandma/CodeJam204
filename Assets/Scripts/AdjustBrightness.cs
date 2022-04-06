using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustBrightness : MonoBehaviour
{
    [SerializeField]
    Slider adjustSlider;

    SensorManager SensorManager;
    [SerializeField]
    ToggleSensors toggleSensors;

    private void Start()
    {
        SensorManager = SensorManager.Instance;
        SensorManager.OnAttitude += AdjustSliderBrightness;

    }

    void AdjustSliderBrightness(Quaternion q)
    {
        if (toggleSensors.isTriggered)
        {
            
        }
    }
}
