using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public Rigidbody2D rb;

    private StaminaBar staminaBar;

    private Vector2 moveMent;
    public float sprintSpeed = 5f;
    public float Speed = 1f;
    public bool isSprinting = false;
    private bool playerHidden = false;
    public bool IsSprinting
    {
        get { return isSprinting; }
    }

    public StaminaBar StaminaBar
    {
        get { return staminaBar; }
    }
    private void Start()
    {
        staminaBar = StaminaBar.instance;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!playerHidden)
        {
            Run();
            AniRun();
        }
    }
    void AniRun()
    {
        if (!playerHidden)
        {
            if (isSprinting && staminaBar.currentStamina > 0)
            {

                rb.velocity = moveMent.normalized * sprintSpeed;
            }
            else
            {

                rb.velocity = moveMent.normalized * Speed;
            }
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

}
