using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ToggleSensors : MonoBehaviour, ButtonState
{
    [SerializeField]
    Button button;

    public bool isTriggered;

    //protected SoundManager soundmanager;

    [SerializeField] AudioClip _clip;

    private void Start()
    {
        button.onClick.AddListener(Toggle);
    }

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
