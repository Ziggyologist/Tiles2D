using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int totalScore = 0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    void Awake()
    {
        //we want to keep the original game session object alive between scenes
        int numGameSessions = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;
        if(numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = totalScore.ToString();

    }


    public void ProcessPlayerDeath()
    {  
        if (playerLives > 1) 
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }

    }

    void TakeLife()
    {
        playerLives--;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        livesText.text = playerLives.ToString();
    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        FindFirstObjectByType<ScenePersist>().ResetScenePersist();
        Destroy(gameObject);
    }
    public void AddToScore(int scoreToAdd)
    {
        totalScore += scoreToAdd;
        scoreText.text = totalScore.ToString();
    }
}
