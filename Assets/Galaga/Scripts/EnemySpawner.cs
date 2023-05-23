using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public int spawnRadius = 25;
    public float spawnRate = 1.0f;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnRate); //spawn enemies every 10 seconds
    }

    void SpawnEnemy()
    {
        float x = spawnRadius*Mathf.Sin(Random.Range(0, Mathf.PI))*Mathf.Cos(Random.Range(0, 2*Mathf.PI));
        float y = spawnRadius*Mathf.Sin(Random.Range(0, Mathf.PI))*Mathf.Sin(Random.Range(0, 2*Mathf.PI));
        float z = spawnRadius*Mathf.Cos(Random.Range(0, Mathf.PI));
        transform.position = new Vector3(x,y,z);
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
