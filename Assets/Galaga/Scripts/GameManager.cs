using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        player.GetComponent<PlayerMovement2>().life = 3;
        player.GetComponent<PlayerMovement2>().score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
