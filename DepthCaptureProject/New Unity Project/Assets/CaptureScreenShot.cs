using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;

public class CaptureScreenShot : MonoBehaviour
{
    public float targetFar;
    public DepthImageEffect m_depth;
    private float camFar;
    private int waitFrame = 0;

    private void Awake()
    {
        m_depth.enabled = false;
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScreenCapture.CaptureScreenshot(Application.dataPath + "/Screenshot.png");

            waitFrame = 1;

        }
        else if (waitFrame == 1)
        {

            camFar = Camera.main.farClipPlane;
            Camera.main.farClipPlane = targetFar;
            m_depth.enabled = true;
            ScreenCapture.CaptureScreenshot(Application.dataPath + "/Screenshot_depth.png");


            waitFrame = 2;
        }
        else if (waitFrame == 2)
        {
            Camera.main.farClipPlane = camFar;
            m_depth.enabled = false;
            waitFrame = 0;
        }


    }
}
