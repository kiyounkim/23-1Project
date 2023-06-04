using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject particle;
    public int minspeed;
    public int maxspeed;
    public int timer;
    public GameObject target;
    public GameObject playerInfo;
    public int info;
    // Start is called before the first frame update
    void Start()
    {
        //get player position
        Vector3 playerPosition = target.transform.position;
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
        Debug.Log("Updating score for PlayerMovement2 instance " + playerInfo.GetComponent<PlayerMovement2>().GetInstanceID());
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player"){
            //playerInfo.GetComponent<PlayerMovement2>().LoseLife();
            info = 1;
            Explode();
        }else if(collision.gameObject.tag == "Bullet"){
            //playerInfo.GetComponent<PlayerMovement2>().AddScore();
            info = 2;
            Explode();
        }else if(collision.gameObject.tag == "Enemy"){
            Explode();
        }
        
        //if collides with player, explode
    }
    void Explode()
    {
        particle = Instantiate(particle, transform.position, Quaternion.identity);
        particle.GetComponent<ParticleSystem>().Play();
        if(info == 1)
            playerInfo.GetComponent<PlayerMovement2>().LoseLife();
        else if(info == 2)
            playerInfo.GetComponent<PlayerMovement2>().AddScore();
        Destroy(gameObject);
    }
}
