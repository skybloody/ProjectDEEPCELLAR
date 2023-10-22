using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineOrbitalTransposer;

public class Hiding : MonoBehaviour
{
    private SpriteRenderer sr;
    private bool playerHidden = false;
    private bool canInteract = false;

    
   

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            TogglePlayerHide();
        }
    }

    private void TogglePlayerHide()
    {
        playerHidden = !playerHidden;

        if (playerHidden)
        {
            sr.sortingOrder = -1;
            
        }
        else
        {
            sr.sortingOrder = 1;
           
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Locker"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Locker"))
        {
            canInteract = false;
        }
    }
}


