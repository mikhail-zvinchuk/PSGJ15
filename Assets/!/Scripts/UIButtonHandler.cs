using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonHandler : MonoBehaviour
{
    AudioListener audioListener;

    void Awake()
    {
        audioListener = GetComponent<AudioListener>();  
    }

    public void ToggleSound()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
