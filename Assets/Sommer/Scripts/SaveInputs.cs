using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Diagnostics;

public class SaveInputs : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_InputField countInput;
    [SerializeField] private Button button;
    [SerializeField] private Button timer;

    public Stopwatch timerWatch;

    SaveToJson saveJson = new SaveToJson();

    public void Start()
    {
        button.onClick.AddListener(SaveInput);
    }

    public void SaveInput()
    {
        var timeName = nameInput.text;
        var timeNumber = int.Parse(countInput.text);

        TimerClass.Timers.Add(new TimerClass(timeName, timeNumber));
        saveJson.WriteTimersToJson();
        CreateTimer();
    }

    private void CreateTimer()
    {
        Instantiate(timer, transform.parent);
        timer.GetComponentInChildren<Text>().text = TimerClass.Timers[0].TimerCount.ToString();
        UnityEngine.Debug.Log("Timer name is: " + TimerClass.Timers[0].TimerName);
        UnityEngine.Debug.Log("Timer has been set to: "+TimerClass.Timers[0].TimerCount.ToString()+" seconds");
    }
}
