using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _backgroundMusic;
    [SerializeField] private AudioClip _harmPlayer;
    [SerializeField] private AudioClip _increaseScore;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        PlayBackgroundMusic();
    }

    private void PlayBackgroundMusic()
    {
        _audioSource.clip = _backgroundMusic;
        _audioSource.Play();
    }

    public void PlayHarmPlayerSound()
    {
        _audioSource.PlayOneShot(_harmPlayer);
    }

    public void PlayIncreaseScoreSound()
    {
        _audioSource.PlayOneShot(_increaseScore);
    }
}
