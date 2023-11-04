using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal"))
        {
            GameWin.isGameWin = true;
            gameObject.SetActive(false);
        }
    }
}
