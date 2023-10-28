using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note_Paper : MonoBehaviour
{
    [SerializeField]
    private Image _noteImage;

    public GameObject MessagePanel;
    public bool Action = false;
    AudioSource audioSource;
    void Start()
    {
        MessagePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action == true)
            {
                MessagePanel.SetActive(false);
                Action = false;
                _noteImage.enabled = true;
                audioSource.Play();
            }
            else if (Action == false)
            {
                MessagePanel.SetActive(true);
                Action = true;
                _noteImage.enabled = false;
                audioSource.Stop();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MessagePanel.SetActive(true);
            Action = true;
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
}