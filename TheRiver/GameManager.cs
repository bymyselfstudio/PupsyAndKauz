using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    #region TODO'S
    /* Add global speed factor -- DONE
     * Add timer -- DONE
     * Tilting kayak should not happen before game start! -- DONE
     * Fíx leaning bug, where kayak stays in leaning position for some reason
     * Add countdown timer
     * Add level counter (so player knows which level he is)
     * Add tree and plants spawner
     * Create new environment
     * Connect kayak color with health value => orange for middle damage, yellow for almost done
     * Healthbar might be a classic healthbar with visible hearts in UI relating to health value
     * After several seconds the game should increase pace
     * Increase spawnrate when game is faster
     * Add yellow heart for bulletproof mode for 5 seconds => starts at level pace 3
     * Correct camera position to see more in the front
     * Correct UI elements to fit in any display resolution
     */
    #endregion

    [SerializeField] Text scoreText, healthText, timerText;
    [Range(1, 5)] public float pace = 1;
    private float currentTime;
    public bool isStopwatchRunning = false;


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
        scoreText.text = "Score: " + Score.ToString();
        healthText.text = "Health: " + Health.ToString();
    }

    public void AddScore(int _scoreToAdd)
    {
        Score += _scoreToAdd;
    }

    public void AddHealth(int _healthToAdd)
    {
        Health += _healthToAdd;
    }

    public void ResetUI()
    {
        Score = 0;
        Health = 100;
        currentTime = 0;

        scoreText.text = "Score: " + Score.ToString();
        healthText.text = "Health: " + Health.ToString();
        timerText.tag = currentTime.ToString(@"mm\:ss\:fff");
    }

    public void Stopwatch()
    {
        currentTime += Time.deltaTime;
        TimeSpan timer = TimeSpan.FromSeconds(currentTime);
        timerText.text = timer.ToString(@"mm\:ss\:fff"); // UI text needed for this line
        if (currentTime > 1.0f)
        {
            isStopwatchRunning = true;
        }
    }

}
