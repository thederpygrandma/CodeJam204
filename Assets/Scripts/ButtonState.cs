using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ButtonState
{
    void TurnOn();

    void TurnOff();

    void Toggle();
}
