using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour
{
    float y;
    // Start is called before the first frame update
    void Start()
    {
        //get object's radius using mesh renderer
        float diameter = GetComponent<MeshRenderer>().bounds.size.x;
        y = 50/diameter;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, y, 0) * Time.deltaTime);
    }
}
