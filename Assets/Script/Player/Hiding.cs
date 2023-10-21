using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineOrbitalTransposer;

public class Hiding : MonoBehaviour
{
    private SpriteRenderer sr;
    private bool playerHidden = false;
    private bool canInteract = false;
    public LayerMask hiddenLayer;
    private Vector3 hiddenPosition;

    private Rigidbody2D rb;
   

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        hiddenPosition = transform.position;
        rb.isKinematic = true;
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.R))
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
            gameObject.layer = hiddenLayer;
            rb.isKinematic = true;
        }
        else
        {
            sr.sortingOrder = 2;
            gameObject.layer = LayerMask.NameToLayer("Player");
            rb.isKinematic = false;
            transform.position = hiddenPosition;
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


