using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSystem : MonoBehaviour
{

    public AudioClip[] footstepSounds;
    public AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        PlayFootstepSound();
    }


    public void PlayFootstepSound()
    {
        if (footstepSounds.Length > 0)
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                int randomSoundIndex = Random.Range(0, footstepSounds.Length);
                audioSource.clip = footstepSounds[randomSoundIndex];
                audioSource.Play();
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            else
            {
                audioSource.Stop();
            }
    }
}
