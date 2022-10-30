using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // speed applied every time player inputs, but can be changed in Unity
    public float playerSpeedDefault = 3.0f;
    // current speed
    private float playerSpeedCurrent = 0.0f;
    // slow down for smoother movement
    private float playerDecreaseSpeed = 0.99f;
    // direction of the last move that we've made
    private Vector3 playerLastDirection = new Vector3();
    // list is used for W or up arrow, A or left arrow, etc
    public List<KeyCode> buttonUp;
    public List<KeyCode> buttonDown;
    public List<KeyCode> buttonLeft;
    public List<KeyCode> buttonRight;
    
    //check which button is pressed
    Vector3 checkMove(List<KeyCode> keyCodeList, Vector3 move)
    {
        foreach (KeyCode element in keyCodeList)
        {
            // Input.GetKey returns true while the user holds down the key
            if (Input.GetKey(element))
            {
                return move;
            }
        }

        return Vector3.zero;
    }

    // movement code
    void playerMove()
    {
        Vector3 thisFrameMove = new Vector3();
        thisFrameMove += CheckMove(buttonUp, Vector3.up);
        thisFrameMove += CheckMove(buttonDown, Vector3.down);
        thisFrameMove += CheckMove(buttonLeft, Vector3.left);
        thisFrameMove += CheckMove(buttonRight, Vector3.right);

        thisFrameMove.Normalize();  //make vector's magnitude 1
        
        //update variables if button is pressed
        if (thisFrameMove.magnitude > 0)
        {
            playerSpeedCurrent = playerSpeedDefault;
            playerLastDirection = thisFrameMove;
        }
        else
        {
            playerSpeedCurrent *= playerDecreaseSpeed;  //decrease speed over time once button is unpressed
        }

        this.transform.Translate(playerLastDirection * Time.deltaTime * playerSpeedCurrent, Space.World);   //update position
    }

    float Target;
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        Target += Time.deltaTime / 125;

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, Target), 0.05f);
        PlayerMove();
    }
}
