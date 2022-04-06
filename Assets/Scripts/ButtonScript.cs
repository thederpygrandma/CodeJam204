using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonScript : MonoBehaviour
{
    //Same principle as creating a variable and not assigning it a value, because it can have different values at different times.
    //The values of the variables and the body of the methods can be customized for the individual objects that need the variables/methods. 

    protected Button button;

    protected bool isTriggered;

    //protected SoundManager soundmanager;

    [SerializeField] AudioClip _clip;

    protected void TurnOn() { }

    protected void TurnOff() { }

    protected void Toggle() { }
}
