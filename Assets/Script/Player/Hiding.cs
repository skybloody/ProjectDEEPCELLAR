using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    private PlayerMovement playermovement;

    public GameObject flashlight;
    public GameObject Fov;
    
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

        if (!canInteract)
        {
            canInteract = false;
        }
    }

    private IEnumerator TogglePlayerHideCoroutine()
    {
        playerHidden = !playerHidden;

        if (playerHidden)
        {
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
            Color newColor = sr.color;
            newColor.a = 1f;
            sr.color = newColor;
            sr.sortingLayerName = "Player";
            gameObject.layer = LayerMask.NameToLayer("Player");
            flashlight.SetActive(true);
            Fov.SetActive(true);

        }
        playermovement.SetCanMove(!playerHidden);

        yield return new WaitForSeconds(0.1f);

        canInteract = true;
    }

    private void TogglePlayerHide()
    {
        
        canInteract = false;

        
        StartCoroutine(TogglePlayerHideCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Locker"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Locker"))
        {
            canInteract = false;
        }
    }
}


