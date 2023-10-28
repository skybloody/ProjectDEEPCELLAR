using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [Header("------------ Audio Source -----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------------ Audio Clip -----------")]
    public AudioClip background;
    public AudioClip glassbroken;
    public AudioClip keycard;
    public AudioClip readnote;
    public AudioClip dooropen;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip eventdummy;
    public AudioClip locker;

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