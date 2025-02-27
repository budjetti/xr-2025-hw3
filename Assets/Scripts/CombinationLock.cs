using System.Collections.Generic;
using UnityEngine;

public class CombinationLock : MonoBehaviour
{
    [SerializeField] private List<int> currentCode;
    [SerializeField] private List<int> solution;
    [SerializeField] private List<GameObject> buttons;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material correctMaterial;
    [SerializeField] private bool opened;
    [SerializeField] private GameObject pricePrefab;
    [SerializeField] private int price;

    public void AddToCode(int digit)
    {
        if(opened)
            return;

        currentCode.Add(digit);
        if(CorrectCode())
        {
            OpenLock();
        }
        else if(currentCode.Count > solution.Count)
        {
            currentCode = new List<int>();
            foreach(GameObject button in buttons)
            {
                button.GetComponent<MeshRenderer>().material = defaultMaterial;
                button.GetComponent<SafeButton>().pressed = false;
            }
        }
    }

    private bool CorrectCode()
    {
        for(int i = 0; i < solution.Count; i++)
        {
            if(currentCode[i] == null || currentCode[i] != solution[i])
            {
                return false;
            }
        }
        return true;
    }

    private void OpenLock()
    {
        opened = true;
        foreach(GameObject button in buttons)
        {
            button.GetComponent<MeshRenderer>().material = correctMaterial;
            button.GetComponent<SafeButton>().pressed = false;
            button.GetComponent<SafeButton>().pressable = false;
        }
        GameManager gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if(gm.AddScore(price))
        {
            GameObject priceTag = Instantiate(pricePrefab, transform.position, transform.rotation) as GameObject;
            priceTag.GetComponent<Price>().price = price;
        }
    }
}
