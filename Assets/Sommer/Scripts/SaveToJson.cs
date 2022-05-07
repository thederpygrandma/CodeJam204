using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
