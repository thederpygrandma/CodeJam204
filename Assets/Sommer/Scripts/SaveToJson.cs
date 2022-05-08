using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveToJson
{
    private string _filePath = @"C:\Unity stuff";
    private readonly string _fileName = "/timers.json";
    public void WriteTimersToJson()
    {
        var outputString = JsonUtility.ToJson(TimerClass.Timers);
        File.WriteAllText(Application.persistentDataPath + _fileName, outputString);
        Debug.Log("File has been saved as json file at: " + Application.persistentDataPath);
        Debug.Log("File has been saved with "+TimerClass.Timers.Count+" amount of numbers in the list.");
    }

    public void ReadTimersToJson()
    {
        var inputString = File.ReadAllText(_fileName);
    }
}
