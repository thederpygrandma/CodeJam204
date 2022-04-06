using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ToggleSensors : MonoBehaviour, ButtonScript
{
    Button button;

    bool isTriggered;

    //protected SoundManager soundmanager;

    [SerializeField] AudioClip _clip;

    public void Toggle()
    {
        if (isTriggered)
        {
            TurnOff();
        } else 
            TurnOn();
        
    }

    public void TurnOff()
    {
        isTriggered = false;
    }

    public void TurnOn()
    {
        isTriggered = true;
    }


 
}
