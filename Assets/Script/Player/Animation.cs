using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator animator;
    private Vector2 moveMent;
    private Vector2 LastMovelDirection;

    private bool facingleft = true;

    void Update()
    {
        PAnimation();

        if (moveMent.x > 0 && !facingleft || moveMent.x < 0 && facingleft)
        {
            Flip();
        }
    }

    void PAnimation()
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
}
