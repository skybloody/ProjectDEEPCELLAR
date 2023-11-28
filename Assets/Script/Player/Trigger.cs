using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Trigger : MonoBehaviour
{
    public Canvas UIHowTo;

    void Start()
    {
        // Disable the UI at the start
        UIHowTo.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UIHowTo.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIHowTo.enabled = false;
        }
    }
}
