using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OneShotSound : MonoBehaviour
{
   
    AudioSource src;
    public AudioClip clip;

    private void Start()
    {
        src = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        OneShot(); 
    }
     
    public void OneShot()
    {
        Keyboard kb = Keyboard.current;
        if (kb == null) { return; }


        if (kb.spaceKey.wasPressedThisFrame)
        {
            src.PlayOneShot(clip); 
        }
    }
}
