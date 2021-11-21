using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTest : MonoBehaviour
{

    private void OnGUI()
    {
#if UNITY_EDITOR
        GUI.Label(new Rect(10, 10, 200, 20), "Runing in Editor");
#elif UNITY_STANDALONE
        GUI.Label(new Rect(10, 10, 200, 20), "Runing in Desktop");
#else
        GUI.Label(new Rect(10, 10, 200, 20), "Runing on other platform");
#endif
    }
}
