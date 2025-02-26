using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor.Animations;

public class Breakable : MonoBehaviour
{
    [SerializeField] private float toughness = 0.01f;
    [SerializeField] private Rigidbody rb;

    [Tooltip("If null, breaks by separating children")]
    [SerializeField] private GameObject brokenVersion;

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
        if(null != brokenVersion)
        {
            Instantiate(brokenVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            while(transform.childCount > 0){
                Transform child = transform.GetChild(0);
                if(null == child.GetComponent<Rigidbody>())
                {
                    child.AddComponent<Rigidbody>();
                }
                child.parent = null;
            }
        }
    }
}
