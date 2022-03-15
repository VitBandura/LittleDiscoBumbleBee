using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
   [SerializeField] private AudioClip _backgroundMusic;

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
}
