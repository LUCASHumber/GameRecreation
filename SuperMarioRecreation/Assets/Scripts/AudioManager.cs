using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;


    [Header("---------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip flagpoleSlide;
    public AudioClip gameEnd;

    private void Start()
    {
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayDeathSound(AudioClip deathClip)
    {
        musicSource.Stop();
        musicSource.clip = deathClip;
        musicSource.loop = false; 
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            SFXSource.PlayOneShot(clip); 
        }
    }

    public void PlayFlagpoleSlideMusic()
    {
        musicSource.Stop();
        musicSource.clip = flagpoleSlide;
        musicSource.loop = true;
        musicSource.Play();
    }

   
    public void PlayGameEndMusic()
    {
        musicSource.Stop();
        musicSource.clip = gameEnd;
        musicSource.loop = false;
        musicSource.Play();
    }
}
