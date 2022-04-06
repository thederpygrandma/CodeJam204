using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSensors : MonoBehaviour
{

    /// If button is pressed, it will check wether or not sensor is on, and behave accordingly.
    public void whenButtonClicked()
    {
        if (InputSystem.DisableDevice(Gyroscope.current); == true)
            InputSystem.EnableDevice(Gyroscope.current);
        else 
            InputSystem.DisableDevice(Gyroscope.current);
        if (Gyroscope.current.enabled)
        Debug.Log("Gyroscope is enabled");

        if (Gyroscope.current.disabled)
        Debug.Log("Gyroscope is disabled");
    }
}
