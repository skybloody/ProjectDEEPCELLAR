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
    AudioManager audioManager;
    void Start()
    {
        MessagePanel.SetActive(false);
    }
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            audioManager.PlaySFX(audioManager.readnote);
            if (Action == true)
            {
                MessagePanel.SetActive(false);
                Action = false;
                _noteImage.enabled = true;
            }
            else if (Action == false)
            {
                MessagePanel.SetActive(true);
                Action = true;
                _noteImage.enabled = false;
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