using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackWall : MonoBehaviour
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
        if(Mathf.Abs(transform.position.z - player.transform.position.z) < 3)
            GetComponent<MeshRenderer>().material = material2;
        else
            GetComponent<MeshRenderer>().material = material1;
    }
}
