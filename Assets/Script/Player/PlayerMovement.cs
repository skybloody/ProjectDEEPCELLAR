using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    private StaminaBar staminaBar;
    public float Speed = 1f;
    public float sprintSpeed = 5f;
    private bool isSprinting = false;

    private bool playerHidden = false;
    public Animator animator;
    
    private Vector2 moveMent;
    private Vector2 LastMovelDirection;
    float x;
    float y;

    void Start()
    {
        rb = GetComponent <Rigidbody2D>();
        staminaBar = StaminaBar.instance;
    }

    void Update()
    {
        ProccessMovementInput();
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (x != 0 || y != 0)
        {

        }
        else
        {

        }
        if (!playerHidden)
        {
            Run();
            AniRun();
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
}
