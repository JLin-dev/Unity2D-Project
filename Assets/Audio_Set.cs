using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Set : MonoBehaviour
{
    AudioSource audio_s;

    public AudioClip[] clip;

    void Start()
    {
        audio_s = GetComponent<AudioSource>();
    }


    public void PlaySfx(int id)
    {
        audio_s.PlayOneShot(clip[id]);
    }
}
