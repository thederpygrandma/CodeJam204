using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveInputs : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_InputField countInput;
    [SerializeField] private Button button;

    public void Start()
    {
        button.onClick.AddListener(SaveInput);
    }

    public void SaveInput()
    {
        var timeName = nameInput.name;
        var timeNumber = int.Parse(countInput.text);

        SaveToJson jsonFile = new SaveToJson();
        TimerClass.Timers.Add(new TimerClass(timeName, timeNumber));
        PrintInput();
        jsonFile.WriteTimersToJson();
    }

    private static void PrintInput()
    {
        Debug.Log(TimerClass.Timers);
    }
}
