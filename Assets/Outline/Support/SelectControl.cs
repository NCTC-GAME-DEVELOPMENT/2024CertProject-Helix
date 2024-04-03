using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectControl : MonoBehaviour
{
    public OutLineInteract LastObject;
    public MouseToWorld MTW; 

    void Start()
    {
        LastObject = null; 
    }

    // Update is called once per frame
    void Update()
    {
        OutLineInteract selection = null;
        if (MTW.worldObject)
        {
            selection = MTW.worldObject.GetComponentInParent<OutLineInteract>();
        }

        if (LastObject != selection)
        {
            // Over Something New. 

            if (LastObject)
            {
                // Do this if LastOBject Isn't Null
                LastObject.OnLeave();
            }

            if (selection)
            {
                // Do this if Selection is null 
                selection.OnHover();
            }
            LastObject = selection;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (LastObject)
            {
                LastObject.OnSelect(); 
            }
        }
    }
}
