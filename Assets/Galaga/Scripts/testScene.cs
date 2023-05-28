using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScene : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the mouse cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        //rotate the object on x and y axis according to user mouse movement(amount of rotation is equal to mouse movement)
        transform.rotation *= Quaternion.Euler(Input.GetAxis("Mouse Y") * 2, Input.GetAxis("Mouse X") * 2, 0);

        //transform.position += new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
        //the object should always stay 10 units away from the object
        transform.position = target.transform.position.normalized * 10;
        transform.position += new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
    }
}
