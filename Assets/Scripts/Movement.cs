using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Movement speeds
    public float defaultSpeed;
    private Animator animation;
    private Rigidbody2D rb;
    private Vector2 direction;

    private GameObject question;
    [SerializeField] AudioSource bg;
    [SerializeField] GameObject questionPanel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();

        question = GameObject.FindGameObjectWithTag("Question");
    }

    void Update()
    {
        //Bounds detection to keep spaceship inside of camera
        if(transform.position.y >= 4.7f)
        {
            transform.position = new Vector3(transform.position.x, 4.7f, 0);
        }
        else if(transform.position.y <= -4.7f)
        {
            transform.position = new Vector3(transform.position.x, -4.7f, 0);
        }

        //Get new direction and speed while spaceship is moving
        //float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");
        direction = new Vector2(0, dirY);

        rb.velocity = new Vector2(0, direction.y * defaultSpeed);

        //Booleans to determine which animation to show as ship is flying
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Question")
        {
            questionPanel.SetActive(true);
            Time.timeScale = 0f;
            bg.Pause();
        }
    }
}