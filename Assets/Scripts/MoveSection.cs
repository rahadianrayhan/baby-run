using System;
using UnityEngine;

public class MoveSection : MonoBehaviour
{


    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3 (speed * Time.deltaTime, transform.position.y, transform.position.z);

        if (transform.position.x < -10f) 
        {
            transform.position = new Vector3(20, transform.position.y, transform.position.z);
        }
    }
}
