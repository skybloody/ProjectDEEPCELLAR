using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door_Easy : MonoBehaviour
{
    public GameObject MessagePanel;
    public GameObject door;
    public Animator animator;
    public bool Action = false;
    AudioManager audioManager;
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            audioManager.PlaySFX(audioManager.keycard);
            Debug.Log("key picked up");
            door.GetComponent<BoxCollider2D>().enabled = false;
            if (Action == true)
            {
                MessagePanel.SetActive(false);
                Action = true;
            }
            else if (Action == false)
            {
                MessagePanel.SetActive(false);
                Action = true;
            }

            this.gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MessagePanel.SetActive(true);
            Action = true;
            animator.SetBool("IsOpenSide", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MessagePanel.SetActive(false);
            Action = false;
            //_noteImage.enabled = false;
        }
    }
    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("IsClose", true);
        }
    }
    */
}
