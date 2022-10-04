using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource soudtrackAudioSource;
    public float fadeTime = 1f;

    private void Start()
    {
        StartCoroutine(FadeIn(soudtrackAudioSource, fadeTime));
    }

    public IEnumerator FadeIn(AudioSource audioSource, float FadeTime) {
        audioSource.Play();
        audioSource.volume = 0f;
        while (audioSource.volume < 1) {
            audioSource.volume += Time.deltaTime / FadeTime;
            yield return null;
        }
    }
}
