using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float _speed;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Animator anim;

    public int coinCounter;
    public int healthPoints;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _movementInput * _speed;
       
    }
    private void Update()
    {
        //CTRL + K + C = COMMENT ALL
        //CTRL + K +U = UNCOMMENT ALL
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    anim.SetTrigger("WalkBackward");
        //}
        //if (Input.GetKeyUp(KeyCode.W))
        //{
        //    anim.SetTrigger("WalkBackwardPause");
        //}

        //gets the horizontal string on animator and adding the movement input x into it.
        anim.SetFloat("Horizontal", _movementInput.x);
        //gets the vertical string on animator and adding the movement input y into it.
        anim.SetFloat("Vertical", _movementInput.y);
        anim.SetFloat("Speed", _movementInput.sqrMagnitude);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins"))
        {
            coinCounter++;
            Destroy(collision.gameObject);
        }
    }


    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}
