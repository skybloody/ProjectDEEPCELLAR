using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight2D : MonoBehaviour
{
    [SerializeField] GameObject candleA;
    private bool candleAActive = false;
    AudioManager audioManager;

    void Start()
    {
        candleA.gameObject.SetActive(false);
    }
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            audioManager.PlaySFX(audioManager.Light);
            if (candleAActive == false)
            {
                candleA.gameObject.SetActive(true);
                candleAActive = true;
            }
            else
            {
                candleA.gameObject.SetActive(false);
                candleAActive = false;
            }
        }
    }

}




