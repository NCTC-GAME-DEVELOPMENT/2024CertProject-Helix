using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
   public void SwitchtoCamera(Camera cam)
    {
        TurnOffAllCams();
        cam.gameObject.SetActive(true);
        MouseToWorld.self.cam = cam; 
    }

    void TurnOffAllCams()
    {
        Camera[] cams = GameObject.FindObjectsByType<Camera>(FindObjectsSortMode.None); 
        foreach (Camera cam in cams)
        {
            cam.gameObject.SetActive(false); 
        }
    }
}
