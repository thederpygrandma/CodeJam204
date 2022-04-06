using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class SensorManager : SingletonPattern<SensorManager>
{
    public TextMeshProUGUI debugtxt;
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

        Debug.Log(LightSensor.current != null);

        //Debug.Log(Accelerometer.current != null);
        //Debug.Log(AttitudeSensor.current != null);
        input.Sensors.Attitude.performed += AttitudeChange;
        input.Sensors.Acceleration.performed += AccelerationChange;
        input.Sensors.Light.performed += LightLevelChange;

        
    }

    private void LightLevelChange(InputAction.CallbackContext ctx)
    {   

        debugtxt.text = ctx.ReadValue<float>().ToString();
        if (OnLightLevel != null) OnLightLevel(ctx.ReadValue<float>());
    }

    private void AccelerationChange(InputAction.CallbackContext ctx)
    {
        
        if(OnAcceleration != null) OnAcceleration(ctx.ReadValue<Vector3>());
    }

    private void AttitudeChange(InputAction.CallbackContext ctx)
    {
        if (OnAttitude != null) OnAttitude(ctx.ReadValue<Quaternion>());
    }
}
