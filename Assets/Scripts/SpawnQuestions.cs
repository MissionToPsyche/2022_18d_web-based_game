using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnQuestions : MonoBehaviour
{
    public GameObject question;

    private float questionMinX = 6f;
    private float questionMaxX = 8f;
    private float questionMinY = -4.3f;
    private float questionMaxY = 4.3f;

    public float timeBetweenSpawn;
    private float spawnTimequestion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnTimequestion)
        {
            SpawnQuestionAsteroid();
            spawnTimequestion = Time.time + timeBetweenSpawn;
        }
    }

    void SpawnQuestionAsteroid()
    {
        float questionRandomX = Random.Range(questionMinX, questionMaxX);
        float questionRandomY = Random.Range(questionMinY, questionMaxY);

        Instantiate(question, transform.position + new Vector3(questionRandomX, questionRandomY, 0), transform.rotation);
    }
}
