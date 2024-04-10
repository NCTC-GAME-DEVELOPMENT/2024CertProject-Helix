using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class OutLineInteract : MonoBehaviour
{
    Outline outline;
    public UnityEvent HoverEvent;
    public UnityEvent LeaveEvent;
    public UnityEvent SelectEvent;

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
        HoverEvent?.Invoke(); 
    }
        

    public virtual void OnLeave()
    {
        if (outline)
        {
            outline.enabled = false;
        }
        LeaveEvent?.Invoke();
    }

    public virtual void OnSelect()
    {
     
        SelectEvent?.Invoke(); 

    }

    public virtual void SetGreen()
    {
        if (outline)
        {
            outline.OutlineColor = Color.green;
        }
    }
}