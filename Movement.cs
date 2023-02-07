using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Movement speeds
    public float defaultSpeed = 2f;
    private Animator animation;
    private Rigidbody2D rb;
    //public Sprite upSprite, downSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 pos = transform.position;

        pos.x += defaultSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        pos.y += defaultSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        transform.position = pos;

        if(rb.velocity.y == 0)
        {
            animation.SetBool("flyingUp", false);
            animation.SetBool("flyingDown", false);
        }

        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            animation.SetBool("flyingUp",  true);
        }

        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            animation.SetBool("flyingDown",  true);
        }
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
