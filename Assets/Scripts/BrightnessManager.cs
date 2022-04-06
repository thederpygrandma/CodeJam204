using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessManager : SingletonPattern<BrightnessManager>
{
    [SerializeField]
    Light SceneLight;

    public void SetBrightnessLevel(float val)
    {
        SceneLight.intensity = val;
    }
}
