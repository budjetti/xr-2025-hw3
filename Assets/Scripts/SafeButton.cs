using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeButton : MonoBehaviour
{
    [SerializeField] private int digit;
    [SerializeField] private Material pressedMaterial;
    [SerializeField] private CombinationLock combinationLock;
    public bool pressed;
    public bool pressable;
    void Start()
    {
        pressable = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(pressable && !pressed && other.tag == "Finger")
        {
            GetComponent<MeshRenderer>().material = pressedMaterial;
            pressed = true;
            combinationLock.AddToCode(digit);
        }
    }
}
