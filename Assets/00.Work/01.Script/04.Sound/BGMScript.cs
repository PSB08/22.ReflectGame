using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour
{
    public AudioClip[] musicClips;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayRandomMusic();
    }

    void PlayRandomMusic()
    {
        if (musicClips.Length > 0)
        {
            int randomIndex = Random.Range(0, musicClips.Length); 
            audioSource.clip = musicClips[randomIndex];
            audioSource.Play(); 
        }
    }
}
