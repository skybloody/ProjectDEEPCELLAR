using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject interaction;
    public GameObject flashlight;
    public GameObject Fov;
    public GameObject Sound;

    private StaminaBar staminaBar;
    public float Speed = 1f;
    public float sprintSpeed = 5f;
    private bool isSprinting = false;

    private bool playerHidden = false;
    private bool canInteract = false;
    public SpriteRenderer sr;
    public Animator animator;
    
    private Vector2 moveMent;
    private Vector2 LastMovelDirection;
    float x;
    float y;

    public Vector2 boxSize = new Vector2(0.1f, 1f);

    void Start()
    {
        interaction.SetActive(false);
        rb = GetComponent <Rigidbody2D>();
        staminaBar = StaminaBar.instance;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            CheckInteraction();
        }

        ProccessMovementInput();
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            TogglePlayerHide();
        }
        if (playerHidden)
        {
            rb.velocity = Vector2.zero;
        }
        
        if (!playerHidden)
        {
            Run();
            AniRun();
        }
    }
    public void OpenInteractableIcon()
    {
        interaction.SetActive(true);
    }

    public void CloseInteractableIcon()
    {
        interaction.SetActive(false);
    }

    private void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        if(hits.Length > 0) 
        {
            foreach(RaycastHit2D rc in hits) 
            {
                if(rc.IsInteractable())
                {
                    rc.Interact();
                    return;
                }
            }
        }
    }

    void ProccessMovementInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (moveX == 0 && moveY == 0 && (moveMent.x != 0 || moveMent.y != 0))
        {
            LastMovelDirection = moveMent;
        }

        moveMent.x = Input.GetAxisRaw("Horizontal");
        moveMent.y = Input.GetAxisRaw("Vertical");

        moveMent.Normalize();
    }

    void AniRun()
    {
        if (!playerHidden)
        {
            if (isSprinting && staminaBar.currentStamina > 0)
            {
                animator.SetBool("IsSprinting", true);
                rb.velocity = moveMent.normalized * sprintSpeed;
            }
            else
            {
                animator.SetBool("IsSprinting", false);
                rb.velocity = moveMent.normalized * Speed;
            }
        }
    }
    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && staminaBar.currentStamina > 0)
        {
            isSprinting = true;
            staminaBar.UseStamina(1);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }
    }

    private void TogglePlayerHide()
    {
        playerHidden = !playerHidden;

        if (playerHidden)
        {
            sr.sortingOrder = 0;
            sr.sortingLayerName = "Hidden";
            flashlight.SetActive(false);
            Fov.SetActive(false);
        }

        else
        {
            sr.sortingOrder = 3;
            sr.sortingLayerName = "Player";
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
