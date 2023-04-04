using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialBackground : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public Rigidbody2D rigidBody;
    private float imageWidth;
    private float scrollSpeed = -1f;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();

        imageWidth = boxCollider.size.x;
        boxCollider.enabled = false;        //save memory, store reference to collider in imageWidth

        rigidBody.velocity = new Vector2(scrollSpeed, 0);       //scroll to left
    }

    // Update is called once per frame
    void Update() { }
}
