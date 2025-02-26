using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Debris : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 startingForces;
    [SerializeField] private float forceScale = 5f;

    void Start()
    {
        if(null == rb)
        {
            rb = GetComponent<Rigidbody>();
        }

        startingForces = startingForces + Vector3.right * (Random.value - 0.5f);
        startingForces = startingForces + Vector3.up * (Random.value - 0.5f);
        startingForces = startingForces + Vector3.forward * (Random.value - 0.5f);

        rb.AddForce(startingForces * forceScale, ForceMode.Impulse);
        rb.AddRelativeTorque(startingForces * 10f);
    }
}
