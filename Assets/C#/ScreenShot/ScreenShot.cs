using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    [SerializeField] private Camera Camera;

    private bool TakeScreenShot = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            TakeScreeShot();
        }
    }

    private void OnPostRender()
    {
        if (TakeScreenShot)
        {
            TakeScreenShot = false;

            RenderTexture t = Camera.targetTexture;

            Texture2D renderResult = new Texture2D(1920, 1080);
            Rect r = new Rect(0, 0, 1920, 1080);
            renderResult.ReadPixels(r, 0, 0);

            byte[] bytearray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes("D:", bytearray);

            //RenderTexture.ReleaseTemporary(t);
            //Camera.targetTexture = null;
        }
    }

    private void TakeScreeShot()
    {
        Camera.targetTexture = RenderTexture.GetTemporary(1920, 1080, 16);
        TakeScreenShot = true;
    }
}
