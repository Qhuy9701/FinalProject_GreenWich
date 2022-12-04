using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource src;
    private void Awake()
    {
        instance = this;
        src = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip _sound)
    {
        src.PlayOneShot(_sound);
    }
}
