using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SensorManager : SingletonPattern<SensorManager>
{
    public delegate void OnAttitudeEvent(Quaternion quat);
    public event OnAttitudeEvent OnAttitude;

    public delegate void OnAccelerationEvent(Vector3 vec);
    public event OnAccelerationEvent OnAcceleration;

    Inputs input;
    private void Awake()
    {
        input = new Inputs();
    }

    private void Start()
    {
        InputSystem.EnableDevice(AttitudeSensor.current);
        InputSystem.EnableDevice(Accelerometer.current);

        input.Sensors.Attitude.performed += AttitudeChange;
        input.Sensors.Acceleration.performed += AccelerationChange;
    }

    private void AccelerationChange(InputAction.CallbackContext ctx)
    {
        OnAcceleration?.Invoke(ctx.ReadValue<Vector3>());
    }

    private void AttitudeChange(InputAction.CallbackContext ctx)
    {
        OnAttitude?.Invoke(ctx.ReadValue<Quaternion>());
    }
}
