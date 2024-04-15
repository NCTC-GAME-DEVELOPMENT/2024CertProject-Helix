using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;



public class InkConvo : MonoBehaviour
{
    public TextAsset InkStory;

    public void Awake()
    {
        InkManager.self.StartInkConvo(InkStory);
        
    }
   

    
}
