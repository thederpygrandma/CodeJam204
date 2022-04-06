using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    FlashLightManager FLM;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(FLM.Toggle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
