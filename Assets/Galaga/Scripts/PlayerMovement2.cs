using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public Rigidbody rigidbody;
    Vector3 movement;
    public int speed;
    public GameObject bulletPrefab;
    public float tiltAngle = 10f;
    public float tiltSpeed = 10f;

    public float cooltime = 0.5f;
    private float lastShot = 0.0f;
    public GameObject aim;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {   
        Move();
        Turn();
        Attack();
    }

    void Turn(){
        transform.rotation *= Quaternion.Euler(-Input.GetAxis("Mouse Y") * 2, Input.GetAxis("Mouse X") * 2, 0);
    }

    void Move(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //Vector3 movement = new Vector3(horizontalInput, Mathf.Abs(Input.GetAxis("Fire3")) > 0 ? -Input.GetAxis("Fire3") : Input.GetAxis("Jump"), verticalInput);
        rigidbody.AddForce(transform.forward * verticalInput * speed);
        rigidbody.AddForce(transform.right * horizontalInput * speed);
        rigidbody.AddForce(transform.up * -Input.GetAxis("Fire3")*speed);
        rigidbody.AddForce(transform.up * Input.GetAxis("Jump")*speed);
        if(Input.GetKeyDown(KeyCode.LeftControl)) rigidbody.velocity = Vector3.zero;
    }

    void Attack(){
        if(Input.GetMouseButtonDown(0)&&Time.time>lastShot+cooltime){
            lastShot = Time.time;
            Instantiate(bulletPrefab, transform.position + transform.forward * 2, transform.rotation);
        }
    }

    void OnCollisionEnter(Collision collision)
    {

    }
}