using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    int r = 25;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, 2.0f); //spawn enemies every 10 seconds
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        float x = r*Mathf.Sin(Random.Range(0, Mathf.PI))*Mathf.Cos(Random.Range(0, 2*Mathf.PI));
        float y = r*Mathf.Sin(Random.Range(0, Mathf.PI))*Mathf.Sin(Random.Range(0, 2*Mathf.PI));
        float z = r*Mathf.Cos(Random.Range(0, Mathf.PI));
        transform.position = new Vector3(x,y,z);
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
