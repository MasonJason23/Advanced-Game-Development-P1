using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource soudtrackAudioSource;
    public float fadeTime = 1f;

    private bool gameEnd = false;

    private void Start()
    {
        FindObjectOfType<GameManager>().changePhase += UpdateCurrentState;
        
        StartCoroutine(FadeIn(soudtrackAudioSource, fadeTime));
    }

    private void Update()
    {
        if (gameEnd)
        {
            StartCoroutine(FadeOut(soudtrackAudioSource, fadeTime));
        }
    }

    void UpdateCurrentState(GamePhase state)
    {
        gameEnd = state == GamePhase.END;
    }
    
    public IEnumerator FadeIn(AudioSource audioSource, float FadeTime) {
        audioSource.Play();
        audioSource.volume = 0f;
        while (audioSource.volume < 1) {
            audioSource.volume += Time.deltaTime / FadeTime;
            yield return null;
        }
    }
    
    public IEnumerator FadeOut(AudioSource audioSource, float FadeTime) {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0.25) {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        gameEnd = false;
    }
}
