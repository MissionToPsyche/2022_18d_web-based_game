using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Movement speeds
    public float defaultSpeed = 9.0f;

    void Start()
    {

    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += defaultSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        transform.position = pos;

        pos.y += defaultSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        // Main idea: avoid asteroids and if one is hit, pull up information about the asteroid that was hit
        if (obj.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
