using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightManager : SingletonPattern<FlashLightManager>
{
    private bool Active;
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
            ///FIX///// 
            camera1.Call("startPreview");
            Active = true;
        }
        else
        {
            Debug.LogError("[CameraParametersAndroid] Camera not available");
        }

    }

    void OnDestroy()
    {
        FL_Stop();
    }

    public void FL_Stop()
    {

        if (camera1 != null)
        {
            camera1.Call("stopPreview");
            camera1.Call("release");
            Active = false;
        }
        else
        {
            Debug.LogError("[CameraParametersAndroid] Camera not available");
        }
    }
    public void Toggle()
    {
        if (Active)
        {
            FL_Stop();
        }
        else
        {
            FL_Start();
        }
    }
}
