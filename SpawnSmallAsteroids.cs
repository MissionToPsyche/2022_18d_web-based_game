using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSmallAsteroids : MonoBehaviour
{   
    public GameObject small;

    private float smallMinX = 5f;
    private float smallMaxX = 8f;
    private float smallMinY = -4.6f;
    private float smallMaxY = 4.6f;

    public float timeBetweenSpawn;
    private float spawnTimesmall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnTimesmall)
        {
            SpawnSmallAsteroid();
            spawnTimesmall = Time.time + timeBetweenSpawn;
        }
    }

    void SpawnSmallAsteroid()
    {
        float smallRandomX = Random.Range(smallMinX, smallMaxX);
        float smallRandomY = Random.Range(smallMinY, smallMaxY);

        Instantiate(small, transform.position + new Vector3(smallRandomX, smallRandomY, 0), transform.rotation);
    }
}