using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    public GameObject flashlight;
    public GameObject Fov;
    public GameObject Sound;
    public SpriteRenderer sr; 
    

    private bool playerHidden = false;
    private bool canInteract = false;
    public Rigidbody2D rb;


    public void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (canInteract && Input.GetMouseButtonDown(1))
        {
            TogglePlayerHide();
        }

        if (playerHidden)
        {
           rb.velocity = Vector2.zero; 
        }
    }

    private void TogglePlayerHide()
    {
        playerHidden = !playerHidden;

        if (playerHidden)
        {
            sr.sortingOrder = 0;
            gameObject.layer = LayerMask.NameToLayer("hidden");
            flashlight.SetActive(false);
            Fov.SetActive(false);
        }

        else
        {
            sr.sortingOrder = 3;
            gameObject.layer = LayerMask.NameToLayer("Player");
            flashlight.SetActive(true);
            Fov.SetActive(true);

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


