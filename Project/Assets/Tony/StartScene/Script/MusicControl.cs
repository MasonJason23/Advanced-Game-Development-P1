using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public List<AudioClip> musicList;
    private AudioSource audioSource;
    private int i;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        i = 0;
    }

    private void Update()
    {
        if(audioSource.isPlaying == false)
        {
            audioSource.clip = musicList[i++];
            audioSource.Play();
        }
    }
}
