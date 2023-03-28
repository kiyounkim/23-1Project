using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector3 lastPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPos = transform.position;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0f, moveZ);

        if (movement.magnitude > 0.1f)
        {
            rb.velocity = movement.normalized * moveSpeed;
            transform.LookAt(transform.position + movement);
            lastPos = transform.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Body"))
        {
            transform.position = lastPos;
            rb.velocity = Vector3.zero;
        }
    }
}
