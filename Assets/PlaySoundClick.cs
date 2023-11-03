using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlaySoundClick : MonoBehaviour
{
    public AudioSource audioClick;
    public AudioSource audioSourceAmbiant;
    private bool flag;
    
    public void PlaySoundClickButton()
    {
        audioClick.Play();
    }

    public void SwitchOffSoundClickButton()
    {
        if (!flag)
        {
            audioClick.volume = 0;
            audioSourceAmbiant.volume = 0;
            flag = true;
        }
        else if (flag)
        {
            audioClick.volume = 1;
            audioSourceAmbiant.volume = 0.1f;
            flag = false;
        }
        
    }
}
