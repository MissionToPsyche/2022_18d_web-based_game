//WORK IN PROGRESS

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject[] levels; //# of objects that we want to loop
    private Camera mainCamera;
    private Vector2 screenBounds;   // used to prevent duplicate items in the same camera frame, as well as looping 

    // Start is called before the first frame update
    void Start()
    {
        //initialize camera, bounds, and objects
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach(GameObject obj in levels)
        {
            loadObjects(obj);
        }
    }

    //load all objects to screen
    void loadObjects(GameObject obj)
    {
        //get object width to find the number of objects needed to populate the screen
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x;
        int objNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth);  //wrong calculation, prints everything in succession, want to randomize location, but is an example to make script work
        GameObject clone = Instantiate(obj) as GameObject;  //clones are duplicated objects
        for(int i = 0; i <= objNeeded; i++)
        {
            GameObject n = Instantiate(clone) as GameObject;
            n.transform.SetParent(obj.transform);   //n's parent is obj (clone)
            n.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);    //new positions for n, x is in succession(need to fix), y and z are just parent's position
            n.name = obj.name + i;  //renaming clone's children
        }
        // cleanup to save resources (destroy clones as screen moves on)
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }
    
    //code to actually move the objects as the screen moves
    void repositionObjects(GameObject obj)
    {
        //list of all children that are in obj
        Transform[] child = obj.GetComponentsInChildren<Transform>();
        if(child.Length > 1)
        {
            GameObject first = child[1].gameObject; //0 = parent, 1 = first child
            GameObject last = child[child.Length - 1].gameObject;
            float objectHalfWidth = last.GetComponent<SpriteRenderer>().bounds.extents.x;   // set transform position to half the width of the object so that transforming happens as the camera passes the half point of the object
            // code to do above mentioned comment
            if(transform.position.x + screenBounds.x > last.transform.position.x + objectHalfWidth) //if first child begins to move beyond the screen border(towards the left)
            {
                first.transform.SetAsLastSibling();     //move first child to end of child[]
                first.transform.position = new Vector3(last.transform.position.x + objectHalfWidth * 2, last.transform.position.y, last.transform.position.z);  //reposition (might need to fix)
            }
            else if(transform.position.x - screenBounds.x < last.transform.position.x - objectHalfWidth) //vice versa of above, move last child to front
            {
                last.transform.SetAsFirstSibling();
                last.transform.position = new Vector3(first.transform.position.x - objectHalfWidth * 2, first.transform.position.y, first.transform.position.z);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        foreach(GameObject obj in levels)
        {
            repositionObjects(obj);
        }
    }
}
