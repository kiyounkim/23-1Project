using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     public Rigidbody rigidbody;
//     Vector3 movement;
//     public float tiltSpeed = 10.0f;
//     public float tiltAngle = 10.0f;
//     public int ylimit;
//     // Start is called before the first frame update
//     void Start()
//     {
//         rigidbody = GetComponent<Rigidbody>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         float horizontalInput = Input.GetAxis("Horizontal");
//         float verticalInput = Input.GetAxis("Vertical");
//         Vector3 movement = new Vector3(horizontalInput, Mathf.Abs(Input.GetAxis("Fire3")) > 0 ? -Input.GetAxis("Fire3") : Input.GetAxis("Jump"), verticalInput);
//         rigidbody.AddForce(movement);
//         float tiltX = verticalInput * tiltAngle * 2;
//         float tiltZ = -horizontalInput * tiltAngle * 2;
//         Quaternion targetTilt = Quaternion.Euler(tiltX, 0, tiltZ);
//         transform.rotation = Quaternion.Slerp(transform.rotation, targetTilt, tiltSpeed * Time.deltaTime);
//         if(Input.GetKeyDown(KeyCode.LeftControl)) rigidbody.velocity = Vector3.zero;

//         Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
//     }
// }
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbody;
    Vector3 movement;
    public float tiltSpeed = 10.0f;
    public float tiltAngle = 10.0f;
    public int ylimit;
    public LineRenderer lineRenderer;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material.color = Color.red;
        
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
        if(Input.GetKeyDown(KeyCode.LeftControl)) rigidbody.velocity = Vector3.zero;

        // Add this line of code to show the ray in the game
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + transform.forward * 10);

        if(Input.GetKeyDown(KeyCode.X)){
            Instantiate(bulletPrefab, transform.position + transform.forward * 2, transform.rotation);
        }
    }
}