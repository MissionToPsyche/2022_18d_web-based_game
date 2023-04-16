using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBigAsteroids : MonoBehaviour
{   
    public GameObject big;

    private float bigMinX = 1f;
    private float bigMaxX = 8f;
    private float bigMinY = -4f;
    private float bigMaxY = 4f;

    public float timeBetweenSpawn;
    private float spawnTimeBig;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnTimeBig)
        {
            SpawnBigAsteroid();
            spawnTimeBig = Time.time + timeBetweenSpawn;
        }
    }

    void SpawnBigAsteroid()
    {
        float bigRandomX = Random.Range(bigMinX, bigMaxX);
        float bigRandomY = Random.Range(bigMinY, bigMaxY);

        Instantiate(big, transform.position + new Vector3(bigRandomX, bigRandomY, 0), transform.rotation);
    }
}
