using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach(GameObject obj in levels)
        {
            loadObjects(obj);
        }
    }

    //load all sprites to screen
    void loadObjects(GameObject obj)
    {
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x;
        int objNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth);
        GameObject clone = Instantiate(obj) as GameObject;
        for(int i = 0; i <= objNeeded; i++)
        {
            GameObject n = Instantiate(clone) as GameObject;
            n.transform.SetParent(obj.transform);
            n.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            n.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }

    void repositionObj(GameObject obj)
    {
        Transform[] child = obj.GetComponentsInChildren<Transform>();
        if(child.Length > 1)
        {
            GameObject first = child[1].gameObject;
            GameObject last = child[child.Length - 1].gameObject;
            float halfObjectWidth = last.GetComponent<SpriteRenderer>().bounds.extents.x;
            if(transform.position.x + screenBounds.x > last.transform.position.x + halfObjectWidth)
            {
                first.transform.SetAsLastSibling();
                first.transform.position = new Vector3(last.transform.position.x + halfObjectWidth * 2, last.transform.position.y, last.transform.position.z);
            }
            else if(transform.position.x - screenBounds.x < last.transform.position.x - halfObjectWidth)
            {
                last.transform.SetAsFirstSibling();
                last.transform.position = new Vector3(first.transform.position.x - halfObjectWidth * 2, first.transform.position.y, first.transform.position.z);
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
            repositionObj(obj);
        }
    }
}
