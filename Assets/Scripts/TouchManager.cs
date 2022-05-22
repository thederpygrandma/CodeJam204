using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : SingletonPattern<TouchManager>
{
    public delegate void OnTouchStart();

    public event OnTouchStart TouchStartEvent;
    
    public delegate void OnTouchEnd();

    public event OnTouchEnd TouchEndEvent;
    
    private Inputs inputs;

    private void Awake()
    {
        inputs = new Inputs();
    }

    private void OnEnable()
    {
        inputs.Touch.Enable();
        inputs.Touch.TouchPressed.started += OnTouchStarted;
        inputs.Touch.TouchPressed.canceled += OnTouchEnded;
    }

    private void OnDisable()
    {
        inputs.Touch.Disable();
        inputs.Touch.TouchPressed.started += OnTouchStarted;
        inputs.Touch.TouchPressed.canceled += OnTouchEnded;
    }

    private void OnTouchStarted(InputAction.CallbackContext ctx)
    {
        TouchStartEvent?.Invoke();
    }
    
    private void OnTouchEnded(InputAction.CallbackContext ctx)
    {
        TouchEndEvent?.Invoke();
    }
}
