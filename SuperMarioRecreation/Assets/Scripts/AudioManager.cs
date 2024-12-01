using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;


    [Header("---------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip smallJump;
    public AudioClip bigJump;
    public AudioClip breakBlock;
    public AudioClip death;
    public AudioClip stomp;
    public AudioClip oneUp;
    public AudioClip powerUp;
    public AudioClip levelFinish;
    public AudioClip flag;
    public AudioClip coin;
    public AudioClip gameOver;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
