using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSensors : MonoBehaviour
{
    void Start()
    {
        InputSystem.EnableDevice(Gyroscope.current);
        if (Gyroscope.current.enabled)
        Debug.Log("Gyroscope is enabled");
    }
}
