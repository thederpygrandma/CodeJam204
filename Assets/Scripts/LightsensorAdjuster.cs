using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightsensorAdjuster : MonoBehaviour
{
    BrightnessManager brightnessManager;
    SensorManager SensorManager;
    float timeElapsed;
    float valueToLerp;
    public TextMeshProUGUI text;
    bool isAnimating = false;


    // Start is called before the first frame update
    void Start()
    {
        brightnessManager = BrightnessManager.Instance;
        SensorManager = SensorManager.Instance;
        SensorManager.OnLightLevel += AdjustBrightness;

    }

    IEnumerator Lerp(float startvalue, float endvalue, float lerpDuration)
    {
        isAnimating = true;
        timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            valueToLerp = Mathf.Lerp(startvalue, endvalue, timeElapsed / lerpDuration);
            brightnessManager.SetBrightnessLevel(valueToLerp);
            timeElapsed += 1;
            text.text = valueToLerp.ToString();
            yield return null;
        }
        valueToLerp = endvalue;
        brightnessManager.SetBrightnessLevel(valueToLerp);
        isAnimating = false;
    }

    void AdjustBrightness(float val)
    {
            if(val < 10 && !isAnimating & brightnessManager.lightInScene.Amount == 0)
            {
                float startvalue = brightnessManager.lightInScene.Amount;
                float endvalue = 1;
                float lerpDuration = 10;
                StartCoroutine(Lerp(startvalue, endvalue, lerpDuration));
            }
            else if(!isAnimating && brightnessManager.lightInScene.Amount == 1)
            {
                float startvalue = brightnessManager.lightInScene.Amount;
                float endvalue = 0;
                float lerpDuration = 10;
                StartCoroutine(Lerp(startvalue, endvalue, lerpDuration));
            }
    }
}
