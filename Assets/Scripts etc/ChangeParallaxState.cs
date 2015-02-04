using UnityEngine;
using System.Collections;
using System.IO;
using System;
using AOT;

public class ChangeParallaxState : MonoBehaviour 
{
    static short MI3D_TN_CMD_OFF = ((short)0x10);
    static short MI3D_TN_CMD_VERTICAL = ((short)0x20);

    #if UNITY_ANDROID || UNITY_EDITOR

    public void ChangeBarrierState(UnityEngine.UI.Toggle toggleNewState)
    {
       CallBarrier(toggleNewState.isOn);
    }

    void CallBarrier(bool newState)
    {
        short mode = MI3D_TN_CMD_VERTICAL;
        if (newState == false)
        {
            mode = MI3D_TN_CMD_OFF;
        }

        try
        {
            using (AndroidJavaClass SDecKit = new AndroidJavaClass("org.sdeck.SDecKit"))
            {
                SDecKit.CallStatic("setTnMode", mode);
            }
        }
        catch (Exception exc)
        {
        }
    }

    void OnApplicationPause()
    {
        CallBarrier(false);
    }

    void OnApplicationQuit()
    {
        CallBarrier(false);
    }

    void Awake()
    {
        CallBarrier(true);
    }

    #endif

}
