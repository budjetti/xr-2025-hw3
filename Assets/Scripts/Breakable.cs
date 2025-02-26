using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor.Animations;
using UnityEngine.SocialPlatforms;

public class Breakable : MonoBehaviour
{
    [SerializeField] private int price;
    [SerializeField] private GameObject pricePrefab;
    [SerializeField] private float toughness = 0.01f;
    [SerializeField] private Rigidbody rb;

    [Tooltip("If null, breaks by separating children")]
    [SerializeField] private GameObject brokenVersion;

    [Tooltip("List of components to remove when broken")]
    [SerializeField] private List<Component> removeWhenBroken;

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
        GameObject priceTag = Instantiate(pricePrefab, transform.position, transform.rotation) as GameObject;
        priceTag.GetComponent<Price>().price = price;

        foreach(Component component in removeWhenBroken)
        {
            Destroy(component);
        }
        
        if(null != brokenVersion)
        {
            GameObject broken = Instantiate(brokenVersion, transform.position, transform.rotation) as GameObject;
            broken.transform.localScale = transform.localScale;
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
