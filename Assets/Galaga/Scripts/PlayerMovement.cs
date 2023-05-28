using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Mouse rotation
    public Camera followCamera;
    

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
        // #1. 키보드에 의한 회전
        // transform.LookAt(transform.position + movement);

        // #2. 마우스에 의한 회전
        // if(Input.GetMouseButtonDown(0)){
            Ray ray = followCamera.ScreenPointToRay(Input.mousePosition); // 마우스 위치를 기준으로 Ray 생성
            RaycastHit rayHit;
            if(Physics.Raycast(ray, out rayHit, 100)){
                Vector3 nextVec = rayHit.point - transform.position;
                transform.LookAt(transform.position + nextVec);
            }
        // }

        // 이건 시발 어떻게 하는거지
        // float minRotation = -90;
        // float maxRotation = 90;

        // Vector3 currentRotation = transform.localRotation.eulerAngles;
        // currentRotation.y = Mathf.Clamp(currentRotation.y, minRotation, maxRotation);
        // transform.localRotation = Quaternion.Euler(currentRotation);
    }

    void OnCollisionEnter(Collision collision)
    {

    }
}