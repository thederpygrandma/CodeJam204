using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SimpleLUT;

public class BrightnessManager : SingletonPattern<BrightnessManager>
{
    public SimpleLUT lightInScene;
    public void SetBrightnessLevel(float val)
    {
        lightInScene.Amount = val;
    }
}
