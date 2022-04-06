using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    FlashLightManager FLM;
    SoundManager sound;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        FLM = FlashLightManager.Instance;
        sound = SoundManager.Instance;
        button.onClick.AddListener(FLM.ToggleLight);
        button.onClick.AddListener(PlayOof);
    }

    // Update is called once per frame

    public void PlayOof()
    {
        if(FLM.active == false)
        {
            sound.PlaySound();
        }
    }
}
