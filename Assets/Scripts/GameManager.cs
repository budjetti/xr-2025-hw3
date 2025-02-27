using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private float roundTime;
    [SerializeField] private float timer;
    [SerializeField] private bool roundStarted;
    [SerializeField] private bool roundOver;
    [SerializeField] private TMP_Text scoreboard;
    [SerializeField] private GameObject playerRig;
    [SerializeField] private Vector3 playerStartingPosition;
    [SerializeField] private Vector3 playerStartingRotation;
    [SerializeField] private SirenLight sirenLight;

    void Start()
    {
        playerStartingPosition = playerRig.transform.position;
        playerStartingRotation = playerRig.transform.rotation.eulerAngles;
        roundStarted = false;
        roundOver = false;
    }
    public void RoundStart()
    {
        if(roundStarted)
            return;

        roundStarted = true;
        score = 0;
        timer = roundTime;
    }

    public bool AddScore(int amount)
    {
        if(roundOver || !roundStarted)
            return false;

        score += amount;
        return true;
    }

    void Update()
    {
        if(roundStarted && !roundOver)
        {
            timer -= Time.deltaTime;
            scoreboard.text = "Damage: " + score + "$\nTime: " + (Mathf.Round(timer * 10f) * 0.1f).ToString() + "s";
            if(timer <= 0)
            {
                RoundEnd();
            }
        }
    }

    void RoundEnd()
    {
        playerRig.transform.position = playerStartingPosition;
        playerRig.transform.eulerAngles = playerStartingRotation;
        roundOver = true;
        scoreboard.text = "Total Damage: " + score + "$";

        AudioSource ac = GetComponent<AudioSource>();
        ac.Play();
        sirenLight.sirens = true;
    }
}
