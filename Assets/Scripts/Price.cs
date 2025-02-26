using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using TMPro;

public class Price : MonoBehaviour
{
    public int price; // set when instantiating

    [SerializeField] private Transform playerCamera;
    [SerializeField] private float shrinkRatio;
    [SerializeField] private float floatSpeed;
    [SerializeField] private float minSize;

    void Start()
    {
        playerCamera = Camera.main.transform;
        GetComponent<TMP_Text>().text = price.ToString() + "$";
    }

    void Update()
    {
        Vector3 newDirection = Vector3.RotateTowards(transform.position, transform.position - playerCamera.position, math.INFINITY, math.INFINITY);
        transform.rotation = Quaternion.LookRotation(newDirection);
    } 
    void FixedUpdate()
    {
        transform.position += new Vector3(0, floatSpeed, 0);
        transform.localScale *= shrinkRatio;
        if(transform.localScale.x <= minSize)
        {
            Destroy(gameObject);
        }
    }
}
