using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutLineInteract : MonoBehaviour
{
    Outline outline;


    void Start()
    {
        outline = gameObject.GetComponent<Outline>();
    }

    public virtual void OnHover()
    {
        if (outline)
        {
            outline.enabled = true;
        }
    }
        

    public virtual void OnLeave()
    {
        if (outline)
        {
            outline.enabled = false;
        }
        
    }

    public virtual void OnSelect()
    {
        if (outline)
        {
            outline.OutlineColor = Color.green;
        }

    }
}