using System;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    [SerializeField]
    private Rigidbody2D rb2D = null;
    [SerializeField]
    private float speed = 3f;

    private Vector2 input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        input = new Vector2(horizontalInput, verticalInput);
        input.Normalize();
    }

    private void FixedUpdate()
    {
        rb2D.linearVelocity = input * speed;
    }
}
