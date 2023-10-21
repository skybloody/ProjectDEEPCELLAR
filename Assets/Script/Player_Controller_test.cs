using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller_test : MonoBehaviour
{
    Rigidbody2D _rb;

    public float _playerSpeed = 5f;
    bool _isGrounded = true;
    bool _isJumping = false;
    float _inputHorizontal;
    public float _playerJumpForce = 8f;
    void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isJumping = true;
        }
    }

    void FixedUpdate()
    {
        _rb.AddForce(new Vector2(_inputHorizontal * _playerSpeed, 0f));
        if (_isGrounded && _isJumping)
        {
            _isGrounded = false;
            _isJumping = false;
            _rb.AddForce(new Vector2(0f, _playerJumpForce));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }
    }
}
