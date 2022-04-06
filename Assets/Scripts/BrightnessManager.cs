using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessManager : SingletonPattern<BrightnessManager>
{

    public void SetBrightnessLevel(float val)
    {
        Screen.brightness = val;
    }
}
