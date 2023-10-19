using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSystem : MonoBehaviour
{
    public Vector2 moveMent;

    private AudioSource audiosource;

    public AudioClip concrete;
    public AudioClip wood;
    public AudioClip dirt;

    public void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    public void Update()
    {
        audioPlayer();
        if (concrete)
        { 
          audiosource.clip = concrete;
        }
        else if(wood) 
        {
            audiosource.clip = wood;
        }

        if (!audiosource.isPlaying)
        {
            audiosource.Play();
        }
    }


    void audioPlayer()
    {
        if (moveMent != Vector2.zero)
        {

            if (!audiosource.isPlaying)
            {
                audiosource.Play();
            }
        }
        else
        {
            audiosource.Stop();
        }

    }
}
