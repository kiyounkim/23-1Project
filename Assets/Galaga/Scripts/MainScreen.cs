using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if any key is pressed, load the game
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Galaga");
        }
    }
}
