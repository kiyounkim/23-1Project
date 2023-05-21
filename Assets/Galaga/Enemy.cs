using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //get player position
        GameObject player = GameObject.Find("Player");
        Vector3 playerPosition = player.transform.position;
        //move toward the center
        GetComponent<Rigidbody>().velocity = (playerPosition - transform.position).normalized * 5;
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
