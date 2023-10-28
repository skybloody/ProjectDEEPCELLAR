using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour
{
    public static bool isGameWin;
    public GameObject gameWinScreen;
    AudioManager audioManager;

    private void Awake()
    {
        isGameWin = false;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (isGameWin)
        {
            audioManager.PlaySFX(audioManager.win);
            gameWinScreen.SetActive(true);
        }
    }
}
