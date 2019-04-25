using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthImageEffect : MonoBehaviour
{
    Shader s = null;
    Material g = null;
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (s == null)
        {
            s = Shader.Find("Hidden/depth");
            g = new Material(s);
        }

        Graphics.Blit(source, destination, g);
    }
}
