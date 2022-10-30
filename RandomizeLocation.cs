// WORK IN PROGRESS

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeLocation : MonoBehaviour
{
    Vector2 randomPosition;
    public float xRange = 3f;
    public float yRange = 3f;

    // Start is called before the first frame update
    // want to randomize locations of each object populated on the screen as it scrolls through
    void Start()
    {
        // getting range of possible positions for object to spawn
        float xPosition = Random.Range(0 - xRange, 0 + xRange);
        float yPosition = Random.Range(0 - yRange, 0 + yRange);
        randomPosition = new Vector2(xPosition, yPosition);
        transform.position = randomPosition;
    }

}
