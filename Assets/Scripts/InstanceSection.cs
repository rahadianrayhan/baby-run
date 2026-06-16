using System;
using UnityEngine;

public class InstanceSection : MonoBehaviour
{
    [SerializeField] GameObject roadSection;
    public Vector3 posInstance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(roadSection, posInstance, Quaternion.identity);
        }
    }
}
