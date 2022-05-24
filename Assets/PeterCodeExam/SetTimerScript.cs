using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class SetTimerScript : SingletonPattern<SetTimerScript>
{
    //Inpsired from tutorial: https://www.youtube.com/watch?v=zHAsc5H0j2c&ab_channel=MetalStormGames

    [SerializeField] private TMP_InputField hours_Input, minutes_Input, seconds_Input;
    
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Button button;

    private bool isAlarmActive = false;
    private DateTime alarmTime = DateTime.Today;

    [SerializeField] private GameObject timerMessage;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(SetAlarm);
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        int hours = DateTime.Now.Hour;
        int minutes = DateTime.Now.Minute;
        int seconds = DateTime.Now.Second;

        timerText.text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";

        if (isAlarmActive && DateTime.Now >= alarmTime)
        {
            TimerIsNow();
        }
    }

    private void SetAlarm()
    {
        TimeSpan ts = TimeSpan.Parse($"{hours_Input.text}:{minutes_Input.text}:{seconds_Input.text}");
        alarmTime += ts;

        isAlarmActive = true;
        Debug.Log("Timer Active Test");
    }

    //The instantiating was attempted with different approaches, but ended up with this. The approach was from multiple sources:
    //https://www.youtube.com/watch?v=m2rS7YebZbY&ab_channel=PkMixture
    //https://stackoverflow.com/questions/60854575/instantiating-a-u-i-object-at-the-position-of-another-object-while-keeping-the-c
    private void TimerIsNow()
    {
        GameObject timerDisplay = Instantiate(timerMessage, transform.position, transform.rotation) as GameObject;
        timerDisplay.transform.SetParent(GameObject.Find("Canvas").transform, false);
        isAlarmActive = false;
        Debug.Log("Timer Test 2");
    }
}
