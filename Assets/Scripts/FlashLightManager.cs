using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightManager : SingletonPattern<FlashLightManager>
{
    public bool active;
    private AndroidJavaObject camera1;


    // code copied from https://stackoverflow.com/questions/25848519/how-turn-on-off-android-flashlight-using-c-sharp-only-in-unity3d 
    public void FL_Start()
    {
        AndroidJavaClass cameraClass = new AndroidJavaClass("android.hardware.Camera");
        WebCamDevice[] devices = WebCamTexture.devices;
        int camID = 0;
        camera1 = cameraClass.CallStatic<AndroidJavaObject>("open", camID);

        if (camera1 != null)
        {
            AndroidJavaObject cameraParameters = camera1.Call<AndroidJavaObject>("getParameters");
            cameraParameters.Call("setFlashMode", "torch");
            camera1.Call("setParameters", cameraParameters);
            camera1.Call("startPreview");
            active = true;
        }
        else
        {
            Debug.LogError("[CameraParametersAndroid] Camera not available");
        }

    }

    /// <summary>
    /// this method ensures that when the application closes the flashlight will also turn off
    /// </summary>
    void OnDestroy()
    {
        FL_Stop();
    }

    /// <summary>
    /// this method will turn off the flashlight if the flashlight is currently available
    /// </summary>
    public void FL_Stop()
    {

        if (camera1 != null)
        {
            camera1.Call("stopPreview");
            camera1.Call("release");
            active = false;
        }
        else
        {
            Debug.LogError("[CameraParametersAndroid] Camera not available");
        }
    }
    /// <summary>
    /// this method will check if the flashlight is currently active. If it is active, the flashlight will be turned off, otherwise it will turn it off
    /// </summary>
    public void ToggleLight()
    {
        if (active)
        {
            FL_Stop();
        }
        else
        {
            FL_Start();
        }
    }
}
