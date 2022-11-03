using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float playerSpeedDefault = 7.0f;
    private float playerSpeedCurrent = 0.0f;
    private float playerDecreaseSpeed = 0.99f;
    private Vector3 playerLastDirection = new Vector3();

    // Use List to have multiple input sources for every direction possible
    public List<KeyCode> buttonUp;
    public List<KeyCode> buttonDown;
    public List<KeyCode> buttonLeft;
    public List<KeyCode> buttonRight;

    // Score 
    public int score = 0;

    Vector3 CheckMove(List<KeyCode> keyCodeList, Vector3 move)
    {
        foreach (KeyCode element in keyCodeList)
        {
            // Input.GetKey returns true while the user holds down the key
            // identified by 'element'
            if (Input.GetKey(element))
            {
                return move;
            }
        }

        return Vector3.zero;
    }

    // Move the player's starship according to WASD buttons
    void PlayerMove()
    {
        Vector3 thisFrameMove = new Vector3();
        thisFrameMove += CheckMove(buttonUp, Vector3.up);
        thisFrameMove += CheckMove(buttonDown, Vector3.down);
        thisFrameMove += CheckMove(buttonLeft, Vector3.left);
        thisFrameMove += CheckMove(buttonRight, Vector3.right);

        thisFrameMove.Normalize();

        if (thisFrameMove.magnitude > 0)
        {
            playerSpeedCurrent = playerSpeedDefault;
            playerLastDirection = thisFrameMove;
        }
        else
        {
            playerSpeedCurrent *= playerDecreaseSpeed;
        }

        this.transform.Translate(playerLastDirection * Time.deltaTime * playerSpeedCurrent, Space.World);
    }

    float Target;
    void Start()
    {

    }

    void Update()
    {
        Target += Time.deltaTime / 125;

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, Target), 0.05f);
        PlayerMove();
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
