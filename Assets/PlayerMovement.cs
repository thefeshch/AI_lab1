using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float speed = 5f;
    private Vector2 movementVector = Vector2.zero;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Debug.Log($"{inputX} - {inputY}");

        movementVector = new Vector2(inputX, inputY).normalized;

    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = movementVector * speed;
    }
}
