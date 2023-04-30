using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyBulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //get player position
        GameObject player = GameObject.Find("Player");
        Vector3 playerPosition = player.transform.position;
        //move toward the player
        GetComponent<Rigidbody>().AddForce((playerPosition - transform.position).normalized * 100);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Position"){
            //stop moving
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            //shoot
            Instantiate(EnemyBulletPrefab, transform.position + transform.forward * 2, transform.rotation);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
