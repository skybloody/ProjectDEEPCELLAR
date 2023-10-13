using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    public SpriteRenderer sr;
    public bool PlayerHide = false;
    private bool canMove = true;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleHide();
        }

        if (PlayerHide && !canMove)
        {
            return;
        }
    }

    void ToggleHide()
    {
        PlayerHide = !PlayerHide;

        if (PlayerHide)
        {

            Physics2D.IgnoreLayerCollision(6, 7, true);
            sr.sortingOrder = 0;
            canMove = false;
        }
        else
        {

            Physics2D.IgnoreLayerCollision(6, 7, false);
            sr.sortingOrder = 2;
            canMove = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Locker"))
        {
            ToggleHide();
        }
    }
}