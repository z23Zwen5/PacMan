using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 10;
    public float rotationSpeed = 500f;
    private Rigidbody2D rb;
    private Vector2 velocity;
    private Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(speed, speed);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        // change facing direction
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90f;  // calculate degree
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        
        Vector2 delta =  moveDirection * velocity * Time.deltaTime;
        Vector2 newPosition = rb.position + delta;
        rb.MovePosition(newPosition);
    }
}
