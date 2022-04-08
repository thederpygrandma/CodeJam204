using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class SensorManager : SingletonPattern<SensorManager>
{
    public delegate void OnAttitudeEvent(Quaternion quat);
    public event OnAttitudeEvent OnAttitude;

    public delegate void OnAccelerationEvent(Vector3 vec);
    public event OnAccelerationEvent OnAcceleration;

    public delegate void OnLightLevelEvent(float val);
    public event OnLightLevelEvent OnLightLevel;

    Inputs input;
    private void Awake()
    {
        input = new Inputs();
    }

    private void OnEnable()
    {
        input.Sensors.Enable();
    }

    private void OnDisable()
    {
        input.Sensors.Disable();
    }


    private void Start()
    {
        InputSystem.EnableDevice(AttitudeSensor.current);
        InputSystem.EnableDevice(Accelerometer.current);
        InputSystem.EnableDevice(LightSensor.current);

        input.Sensors.Attitude.performed += AttitudeChange;
        input.Sensors.Acceleration.performed += AccelerationChange;
        input.Sensors.Light.performed += LightLevelChange;
    }
    /// <summary>
    /// Reads the float value of the light level if anyone is subsribed to the OnLightLevel event
    /// </summary>
    /// <param name="ctx"> Information about the event that occured </param>
    private void LightLevelChange(InputAction.CallbackContext ctx)
    {   
        if (OnLightLevel != null) OnLightLevel(ctx.ReadValue<float>());
    }

    /// <summary>
    /// Reads the vector3 value of the acceleration if anyone is subscribed to the OnAcceleration event
    /// </summary>
    /// <param name="ctx"> Information about the event that occured </param>
    private void AccelerationChange(InputAction.CallbackContext ctx)
    {
        
        if(OnAcceleration != null) OnAcceleration(ctx.ReadValue<Vector3>());
    }

    /// <summary>
    /// Reads the Quaternion value of the gyroscope if anyone is subscribed to the OnAttitude event
    /// </summary>
    /// <param name="ctx"> Information about the event that occured </param>
    private void AttitudeChange(InputAction.CallbackContext ctx)
    {
        if (OnAttitude != null) OnAttitude(ctx.ReadValue<Quaternion>());
    }
}
