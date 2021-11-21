using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class TestPlugin : MonoBehaviour
{
    private static TestPlugin _instance;


    public static void Initialize()
    {
        if (_instance != null)
        {
            Debug.Log("TestPlugin instance was found. Already initialized...");
            return;
        }
        Debug.Log("TestPlugin instance not found. Initializing...");

        GameObject owner = new GameObject("TestPlugin _instance");
        _instance = owner.AddComponent<TestPlugin>();
        DontDestroyOnLoad(_instance);
    }

    #region iOS
    [DllImport("__Internal")]
    private static extern float _TestNumber();

    [DllImport("__Internal")]
    private static extern string _TestString(string test);
    #endregion iOS


    public static float TestNumber()
    {
        float val = 0f;

        if (Application.platform == RuntimePlatform.IPhonePlayer)
            val = _TestNumber();
            return val;
        
    }

    public static string TestString(string test)
    {
        string val = "";
        if (Application.platform == RuntimePlatform.IPhonePlayer)
            val = _TestString(test);
            return val;
        
    }
}
