using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundAmbiant : MonoBehaviour
{
    public GameObject mainSceneCheck;
    public AudioClip soundScene;
    private AudioSource audioAmbiant;
    private bool flag;
    
    public void ChangeSoundAmbiant()
    {
        audioAmbiant.clip = soundScene;
        audioAmbiant.Play();
    }
    private void Start()
    {
        audioAmbiant = GetComponent<AudioSource>();
        audioAmbiant.Play();
    }

    private void Update()
    {
        if (mainSceneCheck.activeInHierarchy)
        {
            if (!flag)
            {
                ChangeSoundAmbiant();
                flag = true;
            }
        }
    }
}
