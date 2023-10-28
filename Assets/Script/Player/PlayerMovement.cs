using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    AudioManager audioManager;

    public float Speed = 1f;
    public float sprintSpeed = 5f;
    AudioSource audiosource;
    [SerializeField] GameObject flashlight;
    [SerializeField] GameObject Fov;

    private SpriteRenderer sr;
    private bool playerHidden = false;
    private bool canInteract = false;
    public LayerMask hiddenLayer;
    public Vector2 moveMent;

    private bool isSprinting = false;
    private StaminaBar staminaBar;

    public Animator animator;
    private Vector2 LastMovelDirection;
    private bool facingleft = true;
    float x;
    float y;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
        staminaBar = StaminaBar.instance;
    }
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Update()
    {
        ProccessAnima();
        Animated();
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (x != 0 || y != 0)
        {
            if (!audiosource.isPlaying)
            {
                audiosource.Play();
            }
        }
        else
        {
            audiosource.Stop();
        }
        if (moveMent.x > 0 && !facingleft || moveMent.x < 0 && facingleft)
        {
            Flip();
        }

        if (!playerHidden) 
        {
            Run();
        }

        if (canInteract && Input.GetKeyDown(KeyCode.C))
        {
            audioManager.PlaySFX(audioManager.locker);
            TogglePlayerHide();
        }


        /* animator.SetFloat("Horizontal", moveMent.x);
         animator.SetFloat("Vertical", moveMent.y);
         animator.SetFloat("Speed", moveMent.sqrMagnitude);*/
    }

    void ProccessAnima()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (moveX == 0 && moveY == 0 && (moveX != 0 || moveY != 0))
        {
            LastMovelDirection = moveMent;
        }

        moveMent.x = Input.GetAxisRaw("Horizontal");
        moveMent.y = Input.GetAxisRaw("Vertical");
        moveMent.Normalize();
    }

    void Animated()
    {
        animator.SetFloat("MoveX", moveMent.x);
        animator.SetFloat("MoveY", moveMent.y);
        animator.SetFloat("MoveMagnitude", moveMent.magnitude);
        animator.SetFloat("LastMoveX", LastMovelDirection.x);
        animator.SetFloat("LastMoveY", LastMovelDirection.y);
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingleft = !facingleft;
    }

    private void Run()
    {
        if (!playerHidden)  
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
