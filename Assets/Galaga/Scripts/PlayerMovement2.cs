using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public Rigidbody rigidbody;
    Vector3 movement;
    // public LineRenderer lineRenderer;
    public GameObject bulletPrefab;
    public float tiltAngle = 10f;
    public float tiltSpeed = 10f;
    //public color
    public Color color;
    public GameObject mainThrust;
    public GameObject leftThrust;
    public GameObject rightThrust;
    public float cooltime = 0.5f;
    private float lastShot = 0.0f;
    public GameObject aim;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        // lineRenderer = gameObject.AddComponent<LineRenderer>();
        // lineRenderer.startWidth = 0.05f;
        // lineRenderer.endWidth = 0.05f;
        // lineRenderer.material.color = Color.red;
        mainThrust.GetComponent<ParticleSystem>().Play();
        leftThrust.GetComponent<ParticleSystem>().Play();
        rightThrust.GetComponent<ParticleSystem>().Play();
    }

    // Update is called once per frame
    void Update()
    {   
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, Mathf.Abs(Input.GetAxis("Fire3")) > 0 ? -Input.GetAxis("Fire3") : Input.GetAxis("Jump"), verticalInput);
        rigidbody.AddForce(movement*2);
        
        Turn();

        //aim
        /*
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.up, horizontalRotation * Time.deltaTime * 100f, Space.World);
        transform.Rotate(Vector3.left, verticalRotation * Time.deltaTime * 100f, Space.Self);
        */
        //movement
        
        // float tiltX = verticalInput * tiltAngle * 2;
        // float tiltZ = -horizontalInput * tiltAngle * 2;
        // Quaternion targetTilt = Quaternion.Euler(tiltX, 0, tiltZ);
        // transform.rotation= Quaternion.Slerp(transform.rotation, targetTilt, Time.deltaTime * tiltSpeed);
        
        // lineRenderer.SetPosition(0, transform.position);
        // lineRenderer.SetPosition(1, transform.position + transform.forward * 10);
        // lineRenderer.enabled = true;
        // lineRenderer.material.color = color;

        if(Input.GetKeyDown(KeyCode.LeftControl)) rigidbody.velocity = Vector3.zero;

        if(Input.GetMouseButtonDown(0)&&Time.time>lastShot+cooltime){
            lastShot = Time.time;
            Instantiate(bulletPrefab, transform.position + transform.forward * 2, transform.rotation);
        }
    }

    void Turn(){
        transform.LookAt(aim.transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {

    }
}