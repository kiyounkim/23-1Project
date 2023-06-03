using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject particle;
    public int minspeed;
    public int maxspeed;
    public int timer;
    public GameObject playerInfo;
    // Start is called before the first frame update
    void Start()
    {
        //get player position
        GameObject player = GameObject.Find("Player");
        Vector3 playerPosition = player.transform.position;
        //move toward the center with random velocity
        GetComponent<Rigidbody>().velocity = (new Vector3(0,0,0) - transform.position).normalized * Random.Range(minspeed, maxspeed);
        //give it random rotation
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * 10;
        //after 5 seconds, explode
        Invoke("Explode", timer);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        // if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag=="Player" || collision.gameObject.tag=="Bullet") Explode();
        
        //PlayerMovement2 playerMovement2 = new PlayerMovement2();

        if(collision.gameObject.tag == "Player"){
            playerInfo.GetComponent<PlayerMovement2>().LoseLife();
            //playerMovement2.LoseLife();
            Explode();
        }else if(collision.gameObject.tag == "Bullet"){
            playerInfo.GetComponent<PlayerMovement2>().AddScore();
            //playerMovement2.AddScore();
            Explode();
        }else if(collision.gameObject.tag == "Enemy"){
            //playerInfo.GetComponent<PlayerMovement2>().AddScore();
            //playerMovement2.AddScore();
            Explode();
        }
        
        //if collides with player, explode
    }
    void Explode()
    {
        particle = Instantiate(particle, transform.position, Quaternion.identity);
        particle.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
    }
}
