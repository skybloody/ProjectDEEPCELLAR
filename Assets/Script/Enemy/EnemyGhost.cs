using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGhost : MonoBehaviour
{
    public float SpeedWalk = 5;
    
    public GameObject target;
    private Animator anim;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private bool facingRight = true;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (transform.position.x > 0 && !facingRight || target.transform.position.x < 0 && facingRight)
        {
            Flip();
        }
    }
    
    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingRight = !facingRight;
    }
}
