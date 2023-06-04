using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontWall : MonoBehaviour
{
    GameObject player;
    public Material material1;
    public Material material2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
                player = GameObject.FindWithTag("Player");
        if(Mathf.Abs(transform.position.z - player.transform.position.z) < 3)
            GetComponent<MeshRenderer>().material = material2;
        else
            GetComponent<MeshRenderer>().material = material1;
    }
}
