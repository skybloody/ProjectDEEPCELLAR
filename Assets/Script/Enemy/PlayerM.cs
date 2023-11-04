using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerM : MonoBehaviour
{
    public float Speed;
    float x, y;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal") * Speed;
        y = Input.GetAxisRaw("Vertical") * Speed;
        rb.velocity = new Vector2 (x, y);
    }
}
