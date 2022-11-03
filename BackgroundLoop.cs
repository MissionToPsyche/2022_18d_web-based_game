using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public Rigidbody2D rigidBody;
    private float imageWidth;
    private float scrollSpeed = -10f;

    void Obstacle()
    {
        transform.GetChild(0).localPosition = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3));
    }
    

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();

        imageWidth = boxCollider.size.x;
        boxCollider.enabled = false;        //save memory, store reference to collider in imageWidth

        rigidBody.velocity = new Vector2(scrollSpeed, 0);       //scroll to left
        Obstacle();
    }

    // Update is called once per frame
    void Update()
    {
        //reset back in place so it can scroll forever
        if (transform.position.x < -imageWidth)
        {
            Vector2 resetPos = new Vector2(imageWidth * 2f, 0);
            transform.position = (Vector2)transform.position + resetPos;
            Obstacle();
        }
    }
}
