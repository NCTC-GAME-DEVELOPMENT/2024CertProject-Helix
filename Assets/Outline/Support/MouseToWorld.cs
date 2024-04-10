using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseToWorld : MonoBehaviour
{

    public Vector3 worldPosition;
    public GameObject worldObject;
    public Camera cam;
    public Transform sphere;
    public Vector3 MousePos;

    public void Update()
    {
        UpdateMouse(Input.mousePosition);
    }

    public void UpdateMouse(Vector3 MousePosin)
    {
        RaycastHit hitInfo;
        MousePos = MousePosin;
        worldPosition = Vector3.zero;
        //MousePos.z = 0; 
        Ray ray = cam.ScreenPointToRay(MousePos);
        if (Physics.Raycast(ray, out hitInfo))
        {
            worldPosition = hitInfo.point;
            worldObject = hitInfo.collider.gameObject;
            if (sphere)
            {
                sphere.position = worldPosition;
            }

        }
        else
        {
            worldObject = null;
        }
    }
}
