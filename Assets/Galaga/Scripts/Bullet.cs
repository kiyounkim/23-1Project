using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        //fly forward
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        Destroy(gameObject, 5);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
