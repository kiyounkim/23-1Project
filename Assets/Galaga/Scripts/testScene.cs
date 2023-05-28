using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the mouse cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        //move the object on x and y axis according to user mouse movement(amount of movement is equal to mouse movement)
        transform.position += new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
    }
}
