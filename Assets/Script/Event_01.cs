using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_01 : MonoBehaviour
{
    private bool hasSoundPlayed = false;
    Animator animator2;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        animator2 = gameObject.GetComponent<Animator>();
    }
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasSoundPlayed)
        {
            audioManager.PlaySFX(audioManager.eventdummy);
            animator2.SetBool("IsEvent", true);

            
            hasSoundPlayed = true;
        }
    }
}
