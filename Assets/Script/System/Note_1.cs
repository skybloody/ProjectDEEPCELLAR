using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note_1 : MonoBehaviour
{
    public GameObject flashlight;
    public Canvas noteCanvas;
    private bool isPlayerInRange = false;

    private void Start()
    {
        noteCanvas.enabled = false;
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Toggle the visibility of noteCanvas
            noteCanvas.enabled = !noteCanvas.enabled;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            flashlight.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            flashlight.SetActive(true);
            noteCanvas.enabled = false;
        }
    }
}
