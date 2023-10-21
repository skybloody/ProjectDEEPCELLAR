using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float Speed = 1f;
    public float sprintSpeed = 5f;
    AudioSource audiosource;


    private SpriteRenderer sr;
    private bool playerHidden = false;
    private bool canInteract = false;
    public LayerMask hiddenLayer;
    private Vector3 hiddenPosition;


    public Vector2 moveMent;

   // public Animator animator;
    private bool isSprinting = false;
    private StaminaBar staminaBar;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
        staminaBar = StaminaBar.instance;
       
    }

    void Update()
    {

        moveMent.x = Input.GetAxisRaw("Horizontal");
        moveMent.y = Input.GetAxisRaw("Vertical");

        if (!playerHidden)  // เพิ่มเงื่อนไขนี้เพื่อตรวจสอบว่าผู้เล่นไม่ได้ซ่อนตัว
        {
            Run();
        }

        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            TogglePlayerHide();
        }


        /* animator.SetFloat("Horizontal", moveMent.x);
         animator.SetFloat("Vertical", moveMent.y);
         animator.SetFloat("Speed", moveMent.sqrMagnitude);*/
    }
    private void Run()
    {
        if (!playerHidden)  // เพิ่มเงื่อนไขนี้เพื่อตรวจสอบว่าผู้เล่นไม่ได้ซ่อนตัว
        {
            if (Input.GetKey(KeyCode.LeftShift) && staminaBar.currentStamina > 0)
            {
                isSprinting = true;
                staminaBar.UseStamina(1);
            }

            if (isSprinting && staminaBar.currentStamina > 0)
            {
                rb.velocity = moveMent.normalized * sprintSpeed;
            }
            else
            {
                rb.velocity = moveMent.normalized * Speed;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isSprinting = false;
            }
        }
    }
    private void TogglePlayerHide()
    {
        playerHidden = !playerHidden;

        if (playerHidden)
        {
            sr.sortingOrder = -1;
            gameObject.layer = hiddenLayer;
            
        }
        else
        {
            sr.sortingOrder = 2;
            gameObject.layer = LayerMask.NameToLayer("Player");
            
            
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
