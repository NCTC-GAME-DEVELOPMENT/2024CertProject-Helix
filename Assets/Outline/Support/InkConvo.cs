using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events; 
using Ink.Runtime;



public class InkConvo : MonoBehaviour
{
    public TextAsset InkStory;
    public UnityEvent PostConvoCall;

    public void PlayInkConvo()
    {
        InkManager.self.StartInkConvo(InkStory);
    }

    public void CallPostConversation()
    {
        PostConvoCall?.Invoke(); 
    }
   

    
}
