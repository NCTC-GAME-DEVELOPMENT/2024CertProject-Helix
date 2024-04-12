using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkConvo : MonoBehaviour
{
    public string InkConvoFile = "No File"; 

    public void RunInk()
    {
        // Debug.Log("Ink File Start :: " + InkConvoFile); 
        InkManager.self.StartInkConvo(InkConvoFile); 
    }
}
