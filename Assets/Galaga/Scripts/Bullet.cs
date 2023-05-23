using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //fly forward
        GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
