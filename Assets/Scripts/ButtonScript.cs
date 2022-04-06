using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonScript : MonoBehaviour
{
    //Same principle as creating a variable and not assigning it a value, because it can have different values at different times.
    //The values of the variables and the body of the methods can be customized for the individual objects that need the variables/methods. 

    protected abstract Button button;

    protected abstract bool isTriggered;

    //protected SoundManager soundmanager;

    [SerializeField] abstract AudioClip _clip;

    protected abstract void TurnOn() { }

    protected abstract void TurnOff() { }

    protected abstract void Toggle() { }
}
