using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour
{
    public static bool isGameWin;
    public GameObject gameWinScreen;

    private void Awake()
    {
        isGameWin = false;
    }

    void Update()
    {
        if (isGameWin)
        {
            gameWinScreen.SetActive(true);
        }
    }
}
