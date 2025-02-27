using UnityEngine;

public class SirenLight : MonoBehaviour
{
    [SerializeField] private Light light;
    public bool sirens = false;

    void Update()
    {
        if(sirens)
        {
            light.color = Mathf.Round(Time.time) % 2 == 0 ? Color.red : Color.blue;
        }
    }
}
