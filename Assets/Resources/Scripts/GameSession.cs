using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int health = 3;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHealth()
    {
        return health;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void SubtractFromHealth(int damageValue)
    {
        health -= damageValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
