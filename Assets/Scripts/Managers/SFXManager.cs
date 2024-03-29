﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Clip { Cut, Swap, Clear };
public class SFXManager : MonoBehaviour
{
    
    public static SFXManager instance;

    private AudioSource[] sfx;

    // Use this for initialization
    void Start()
    {
        instance = GetComponent<SFXManager>();
        sfx = GetComponents<AudioSource>();
    }

    public void PlaySFX(Clip audioClip)
    {
        sfx[(int)audioClip].Play();
    }
}
