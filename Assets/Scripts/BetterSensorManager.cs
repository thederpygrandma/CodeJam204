using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class BetterSensorManager : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI text;
    public Inputs Inputs;
    private void Awake()
    {
        Inputs = new Inputs();
        //InputSystem.EnableDevice(LightSensor.current);
    }
    // Start is called before the first frame update
    void Start()
    {
        InputSystem.EnableDevice(LightSensor.current);
        //Inputs.Sensors.
    }

    // Update is called once per frame
    void Update()
    {
        // InputSystem.DisableDevice(LightSensor.current);
        // InputSystem.EnableDevice(LightSensor.current);
        if (LightSensor.current.enabled)
        {
            var CurrentLight = LightSensor.current.lightLevel.ReadValue();
            text.text = "Light level " + CurrentLight;
        }
       /* else
        {
            var CurrentLight = LightSensor.current.lightLevel.ReadValue();
            text.text = "Light level " + CurrentLight;
        }*/
      
    }
}
