using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector2 movement;
    private Rigidbody rb;

    private void Start()
    {
        movement = Vector2.zero;
        rb = transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        Vector2 dir = (movement - new Vector2(transform.position.x, transform.position.y)).normalized;
        rb.MovePosition(transform.position + new Vector3(movement.x, movement.y, 0f) * Time.deltaTime * moveSpeed);
    }
}
