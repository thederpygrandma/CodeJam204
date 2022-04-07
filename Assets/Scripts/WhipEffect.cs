using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhipEffect : MonoBehaviour
{
    SoundManager sound;
    FlashLightManager FLM;
    float thresh = 5f;
    bool trigger = false;
    private Vector3 accelInfo;
    public TMPro.TMP_Text text;
    [SerializeField]
    private ToggleButton toggleAccelButton;
    private bool isOn = false;
    private float waitTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        sound = SoundManager.Instance;
        FLM = FlashLightManager.Instance;
        SensorManager.Instance.OnAcceleration += Whatever;
        toggleAccelButton.Clicked += OnToggleAccelClicked;
    }

    private void OnToggleAccelClicked(bool isOn)
    {

        this.isOn = isOn;
    }

    IEnumerator ToggleHold(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        trigger = false;
        yield return new WaitForSeconds(waitTime);
    }
    void Whatever(Vector3 vector)
    {
        if (isOn)
        {
            accelInfo = vector;
            if (accelInfo.magnitude > thresh)
            {
                if (!trigger)
                {
                    trigger = true;
                    Debug.Log("test");
                    FLM.ToggleLight();
                    sound.PlaySound();
                    StartCoroutine(ToggleHold(waitTime));
                }
                /*else if (accelInfo.magnitude < thresh)
                {
                    sound.Stop();
                }*/
            }
        }
    }
}