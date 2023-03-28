using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbody;
    Vector3 movement;
    public float tiltSpeed = 10.0f;
    public float tiltAngle = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, Mathf.Abs(Input.GetAxis("Fire3")) > 0 ? -Input.GetAxis("Fire3") : Input.GetAxis("Jump"), verticalInput);
        rigidbody.AddForce(movement);
        float tiltX = verticalInput * tiltAngle * 2;
        float tiltZ = -horizontalInput * tiltAngle * 2;
        Quaternion targetTilt = Quaternion.Euler(tiltX, 0, tiltZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetTilt, tiltSpeed * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.LeftControl)){
            rigidbody.velocity = Vector3.zero;
        }
    }
}