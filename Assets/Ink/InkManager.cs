using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkManager : MonoBehaviour
{
    public static InkManager self;

    private void Awake()
    {
        self = this; 
    }

    public void StartInkConvo(string InkFileName)
    {
        Debug.Log("Manager Is starting inkfile:: " + InkFileName); 
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
