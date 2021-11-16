using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int Score { get; set; }
    [SerializeField] Text scoreText, healthText;

    private static int health;
    public static int Health
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

        scoreText.text = "Score: " + Score.ToString();
        healthText.text = "Health: " + Health.ToString();
    }
}
