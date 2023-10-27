using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSystem : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip[] footstepSounds;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFootstepSound()
    {
        if (footstepSounds.Length > 0)
        {
            int randomSoundIndex = Random.Range(0, footstepSounds.Length);
            audioSource.clip = footstepSounds[randomSoundIndex];
            audioSource.Play();
        }
    }
}
