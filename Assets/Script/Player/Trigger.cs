using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    public Canvas UIHowTo;
    public GameObject Trigger2;

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
            // ปิด UI
            UIHowTo.enabled = false;
            Trigger2.SetActive(false);
        }
    }
}