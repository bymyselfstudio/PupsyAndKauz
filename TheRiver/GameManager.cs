using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text scoreText, healthText, timerText;
    [Range(1, 5)] public int pace;
    public float spawnRepeatTime;
    public float xPlayerSpeed;
    private float currentTime;

    public int Score { get; set; }
    private int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            
            if (health >= 100)
            {
                health = 100;
            }
            else if (health <= 0)
            {
                health = 0;
                Debug.Log("GAME OVER!");
            }
        }
    }

    void Start()
    {
        ResetUI();
    }

    void Update()
    {
        Stopwatch();
        CheckPace();
    }

    public void AddScore(int _scoreToAdd)
    {
        Score += _scoreToAdd;
        scoreText.text = "Score: " + Score.ToString();
    }

    public void AddHealth(int _healthToAdd)
    {
        Health += _healthToAdd;
        healthText.text = "Health: " + Health.ToString();
    }

    public void ResetUI()
    {
        Score = 0;
        Health = 100;
        currentTime = 0;
        pace = 2;
        spawnRepeatTime = 0.5f;
        xPlayerSpeed = 20;

        scoreText.text = "Score: " + Score.ToString();
        healthText.text = "Health: " + Health.ToString();
        timerText.text = currentTime.ToString(@"mm\:ss\:fff");
    }

    public void Stopwatch()
    {
        currentTime += Time.deltaTime;
        TimeSpan timer = TimeSpan.FromSeconds(currentTime);
        timerText.text = timer.ToString(@"mm\:ss\:fff"); // UI text needed for this line
    }

    void CheckPace()
    {
        switch (pace)
        {
            case 1:
                spawnRepeatTime = 0.6f;
                xPlayerSpeed = 18;
                break;
            case 2:
                spawnRepeatTime = 0.7f;
                xPlayerSpeed = 20;
                break;
            case 3:
                spawnRepeatTime = 0.8f;
                xPlayerSpeed = 22;
                break;
            case 4:
                spawnRepeatTime = 0.9f;
                xPlayerSpeed = 25;
                break;
            case 5:
                spawnRepeatTime = 1f;
                xPlayerSpeed = 30;
                break;
        }
    }

}
