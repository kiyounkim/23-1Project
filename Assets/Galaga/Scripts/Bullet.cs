using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        //fly forward
        GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag=="Wall") {
            //play particle
            if(collision.gameObject.tag == "Enemy")
            {
                particle = Instantiate(particle, transform.position, Quaternion.identity);
                particle.GetComponent<ParticleSystem>().Play();
            }
            Destroy(gameObject);
        }
    }
}
