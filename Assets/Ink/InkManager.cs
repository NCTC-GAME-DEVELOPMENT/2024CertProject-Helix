using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkManager : MonoBehaviour
{

    public static InkManager self;

    private void Awake()
    {
        self = this; 
    }

    public void StartInkConvo(TextAsset InkFileName)
    {
        Debug.Log("Manager Is starting inkfile");
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
