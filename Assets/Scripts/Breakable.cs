using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] private float toughness = 0.01f;
    [SerializeField] private Rigidbody rb;

    void Start()
    {
        if(null == rb)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(rb.velocity.magnitude > toughness || other.rigidbody.velocity.magnitude > toughness)
        {
            Break();
        }
    }

    void Break()
    {
        foreach(Transform child in transform)
        {
            if(null == child.GetComponent<Rigidbody>())
            {
                child.AddComponent<Rigidbody>();
            }
            child.parent = null;
        }
        Destroy(this);
    }
}
