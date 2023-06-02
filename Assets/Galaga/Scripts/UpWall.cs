using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpWall : MonoBehaviour
{
    public GameObject player;
    public Material material1;
    public Material material2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(transform.position.y - player.transform.position.y) < 3)
            GetComponent<MeshRenderer>().material = material2;
        else
            GetComponent<MeshRenderer>().material = material1;
    }
}