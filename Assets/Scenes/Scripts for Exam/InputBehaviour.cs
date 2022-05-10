using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InputBehaviour : MonoBehaviour
{
    public List<string> roomNames = new List<string>();
    [SerializeField]
    private Button createRoom;
    [SerializeField]
    private TMP_InputField inputField;
    [SerializeField]
    TextMeshProUGUI text;
    // Update is called once per frame
    void Start()
    {
        createRoom.onClick.AddListener(AddRoom);
    }


    private void AddRoom()
    {
        roomNames.Add(inputField.text);
        text.text = inputField.text;
        Instantiate(text, transform.parent);
    }
}
