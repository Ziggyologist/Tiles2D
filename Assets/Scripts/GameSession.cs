using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
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
        Debug.Log("current lives: " + playerLives);
    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
