using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject interaction;
    public StaminaBar staminaBar;

    public float Speed = 1f;
    public float sprintSpeed = 5f;
    public bool isSprinting = false;
    public bool IsSprinting
    {
        get { return isSprinting; }
    }

    public StaminaBar StaminaBar
    {
        get { return staminaBar; }
    }

    private bool playerHidden = false;
    private bool canMove = true;


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
       
    }

    void Update()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CheckInteraction();
                //TryCollectKey();
            }


            ProccessMovementInput();
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");

            if (!playerHidden)
            {
                Run();
                AniRun();
            }
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
          
            float speed = isSprinting && staminaBar.currentStamina > 0 ? sprintSpeed : Speed;
            rb.velocity = moveMent.normalized * speed;
        }
    }
    private void Run()
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
    public void SetCanMove(bool move)
    {
        canMove = move;
    }
    /*private void TryCollectKey()
    {
        // ใช้ Raycast เพื่อตรวจสอบว่ามี key อยู่หน้า player หรือไม่
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            if (hit.collider.CompareTag("Key"))
            {
                // เรียกฟังก์ชันใน Script ของ key เพื่อทำการเก็บ key
                KeyDoor keyController = hit.collider.GetComponent<KeyDoor>();
                if (keyController != null)
                {
                    keyController.CollectKey();
                }
            }
        }
    }*/
}
