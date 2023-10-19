using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float Speed = 1f;
    public float sprintSpeed = 5f;
    AudioSource audiosource;
    public LayerMask enemyLayer;
    public Transform enemyTransform;


    public Vector2 moveMent;

   // public Animator animator;
    private bool isSprinting = false;
    private StaminaBar staminaBar;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
        staminaBar = StaminaBar.instance;
    }

    void Update()
    {
        moveMent.x = Input.GetAxisRaw("Horizontal");
        moveMent.y = Input.GetAxisRaw("Vertical");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, enemyTransform.position - transform.position, Mathf.Infinity, enemyLayer);

        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            // Player มองเห็นศัตรู
            // ทำสิ่งที่คุณต้องการทำเมื่อ Player มองเห็นศัตรู
        }
        else
        {
            // Player ไม่มองเห็นศัตรู
            // ทำสิ่งที่คุณต้องการทำเมื่อ Player ไม่มองเห็นศัตรู
        }

        /* animator.SetFloat("Horizontal", moveMent.x);
         animator.SetFloat("Vertical", moveMent.y);
         animator.SetFloat("Speed", moveMent.sqrMagnitude);*/

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
