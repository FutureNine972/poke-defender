using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    [SerializeField] float loadDelay = 1f;

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void LoadLose()
    {
        StartCoroutine(DelayForLoad());
    }
    public void LoadStart()
    {
        SceneManager.LoadScene("Start Menu");
    }
    IEnumerator DelayForLoad()
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene("Game Over");
    }
}