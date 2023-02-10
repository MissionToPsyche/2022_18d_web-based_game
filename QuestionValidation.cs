using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionValidation : MonoBehaviour
{
    public Text scoreText;
    private float score;
    [SerializeField] GameObject q1;
    [SerializeField] GameObject q2;
    [SerializeField] GameObject q3;
    [SerializeField] GameObject q4;
    [SerializeField] GameObject q5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null )
        {

        }
    }

    public void Correct()
    {
        
    }
}
