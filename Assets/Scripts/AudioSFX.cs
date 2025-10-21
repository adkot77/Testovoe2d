
using UnityEngine;


public class AudioSFX : MonoBehaviour
{
    private AudioSource audioSource;
    public static AudioSFX instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        

    }

    //public  void PlayMusic(AudioClip music)
    //{
    //    audioSource.clip = music;
    //    audioSource.loop = true;
    //    audioSource.Play();
    //}

    public  void PlaySFX(AudioClip sfx)
    {
        audioSource.PlayOneShot(sfx); 
    }
}
