using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource SFX;
    [SerializeField] public AudioSource Music;
    public static AudioManager instance;
    public AudioClip MusicBg;
    public AudioClip Step;
    public AudioClip Jump;
    public AudioClip Death;
    public AudioClip CollectCoin;
    public AudioClip Confirm;
    public AudioClip Pause;
    public AudioClip Unpause;
    public AudioClip PlatformCrash;
    

    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
            return;
        }
        Music.clip = MusicBg;
        Music.loop = true; 
        Music.Play();
    }
}
