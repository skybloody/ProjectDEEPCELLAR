using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    private PlayerMovement playermovement;

    public GameObject flashlight;
    public GameObject Fov;
    public GameObject Sound;
    public SpriteRenderer sr; 
    

    private bool playerHidden = false;
    private bool canInteract = false;
    


    public void Start()
    {
       playermovement = GetComponent<PlayerMovement>();
       sr = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            TogglePlayerHide();
        }

        if (playerHidden)
        {
            playermovement.rb.velocity = Vector2.zero; 
        }
    }

    private void TogglePlayerHide()
    {
        playerHidden = !playerHidden;

        if (playerHidden)
        {
            sr.sortingOrder = -1;
            Color newColor = sr.color;
            newColor.a = 0f;
            sr.color = newColor;
            sr.sortingLayerName = "hidden";
            gameObject.layer = LayerMask.NameToLayer("hidden");
            flashlight.SetActive(false);
            Fov.SetActive(false);
        }

        else
        {
            sr.sortingOrder = 3;
            Color newColor = sr.color;
            newColor.a = 1f;
            sr.color = newColor;
            sr.sortingLayerName = "Player";
            gameObject.layer = LayerMask.NameToLayer("Player");
            flashlight.SetActive(true);
            Fov.SetActive(true);

        }
        playermovement.SetCanMove(!playerHidden);
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


