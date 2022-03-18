using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _backgroundMusic;
    [SerializeField] private AudioClip _harmPlayerSound;
    [SerializeField] private AudioClip _increaseScoreSound;

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
        _audioSource.PlayOneShot(_harmPlayerSound);
    }

    public void PlayIncreaseScoreSound()
    {
        _audioSource.PlayOneShot(_increaseScoreSound);
    }
}
