using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField]
    private ToggleButton toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle.Clicked += Hello;
    }

    public void Hello(bool isOn)
    {
        Debug.Log(isOn);
    }
}
