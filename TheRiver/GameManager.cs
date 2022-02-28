using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    [Range(1, 5)] public byte pace;
    public Text scoreText, countdownText, speedLevelText;
    public SpawnManager spawnManager;
    public EnvironmentHandler environmentHandler;
    public SceneManager sceneManager;
    public Slider healthSlider;
    public Gradient gradient;
    public Image fill;
    public Light directionalLight;
    public float spawnRepeatTime;
    public readonly float firstSpawnDelay = 0.5f;
    public float xPlayerSpeed;
    public bool isLevelKeyCollected;


    private AudioSource gameAudio;
    private float currentGameTime;
    private float currentCountdownTime = 0;
    private float startingCountdownTime = 3;
    private readonly byte maxScore = 250;
   
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
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    void Awake()
    {
        gameAudio = GetComponent<AudioSource>();
        Screen.orientation = ScreenOrientation.Landscape;
        //Screen.SetResolution(1920, 1080, true);
        directionalLight.intensity = 1.5f;
    }

    void Start()
    {
        ResetUI();
        gameAudio.PlayDelayed(startingCountdownTime);
    }

    void Update()
    {
        StartCountdown();
        Stopwatch();
        CheckPace();

        if (currentGameTime > 30)
        {
            pace = 2;
        }

        if (currentGameTime > 60)
        {
            pace = 3;
        }

        if (currentGameTime > 120)
        {
            pace = 4;
        }

        if (currentGameTime > 180)
        {
            pace= 5;
        }
    }

    public void AddScore(int _scoreToAdd)
    {
        Score += _scoreToAdd;
        scoreText.text = Score.ToString();

        if (Score >= maxScore)
        {
            isLevelKeyCollected = true;
            SceneManager.LoadScene("EndScreen");
            gameAudio.Play();
        }
    }

    public void AddHealth(int _healthToAdd)
    {
        Health += _healthToAdd;
        healthSlider.value = Health;
        fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }

    public void ResetUI()
    {
        Score = 0;
        Health = 100;
        fill.color = gradient.Evaluate(1f);
        currentGameTime = 0;
        pace = 1;
        spawnRepeatTime = 0.5f;
        xPlayerSpeed = 20;
        isLevelKeyCollected = false;
        currentCountdownTime = startingCountdownTime;
        scoreText.text = Score.ToString();
        countdownText.enabled = true;
    }

    public void Stopwatch()
    {
        currentGameTime += 1 * Time.deltaTime;
        if (currentGameTime >= 4)
        {
            countdownText.enabled = false;
        }
    }

    public void StartCountdown()
    {
        currentCountdownTime -= 1 * Time.deltaTime; 
        countdownText.text = currentCountdownTime.ToString("0");

        if (currentCountdownTime <= 0f)
        {
            countdownText.text = "GO!";
        }
    }

    void CheckPace()
    {
        switch (pace)
        {
            case 1:
                spawnRepeatTime = 0.6f;
                xPlayerSpeed = 18;
                speedLevelText.text = "Level  " + pace;
                break;
            case 2:
                spawnRepeatTime = 0.7f;
                xPlayerSpeed = 20;
                speedLevelText.text = "Level  " + pace;
                break;
            case 3:
                spawnRepeatTime = 0.8f;
                xPlayerSpeed = 22;
                speedLevelText.text = "Level  " + pace;
                break;
            case 4:
                spawnRepeatTime = 0.9f;
                xPlayerSpeed = 25;
                speedLevelText.text = "Level  " + pace;
                break;
            case 5:
                spawnRepeatTime = 1f;
                xPlayerSpeed = 30;
                speedLevelText.text = "Level  " + pace;
                break;
        }
    }

}
