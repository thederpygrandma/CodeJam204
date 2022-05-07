using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerClass
{
    private readonly int _maxTimer = 60;
    private readonly int _minTimer = 1;
    public string TimerName { get; set; }
    public int TimerCount { get; private set; }

    private static List<TimerClass> _timers;
    public static List<TimerClass> Timers
    {
        get
        {
            if( _timers == null )
                _timers = new List<TimerClass>();

            return _timers;
        }
    }

    public TimerClass(string timerName, int timerCount)
    {
        TimerName = timerName;

        SetTimer(timerCount);
    }

    /*public TimerClass(string timerName)
    {
        TimerName = timerName;
        TimerCount = 0;
    }*/

    public void SetTimer(int newTimerCount)        
    {
        if (newTimerCount > _maxTimer)
            throw new ArgumentException("TimerCount must be less than " + _maxTimer);
        if (newTimerCount < _minTimer)
            throw new ArgumentException("TimerCount must be more than " + _minTimer);
        TimerCount = newTimerCount;
    }

}

public class SaveToJson
{
    private readonly string _fileName = "/timers.json";
    public void WriteTimersToJson()
    {
        var jsonString = JsonUtility.ToJson(TimerClass.Timers);
        File.WriteAllText(Application.persistentDataPath + _fileName, jsonString);
    }

    public void ReadTimersToJson()
    {
        File.ReadAllText(_fileName);
    }
}

public class SaveInputs
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_InputField countInput;
    
    public void SaveInput()
    {
        var timeName = nameInput.name;
        var timeNumber = int.Parse(countInput.text);

        TimerClass.Timers.Add(new TimerClass(timeName, timeNumber));
    }
}
