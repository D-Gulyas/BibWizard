using System.Collections;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private static bool isInitialized = false;

    public string state = "Start";

    public int score;

    private float Counter;

    public GameObject pause;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            score = 0;

            
            if (!isInitialized)
            {
                isInitialized = true;
                StatsManager.Initialize(); 
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        if (state == "Game")
        {
            Counter += Time.deltaTime;
            if (Counter >= 10)
            {
                ReturnToTitle();
                Counter = 0;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (pause.activeSelf)
                {
                    pause.SetActive(false);
                    Time.timeScale = 1f;
                }
                else
                {
                    pause.SetActive(true);  // pause.SetActive(!pause.activeSelf); -- Andere Schreibweise bzw. kürzere Schreibweise
                    Time.timeScale = 0f;
                }
                 
            }

        }
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("StartScreen");
        state = "Start";
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene("Game");
        state = "Game";
    }

    public void OnNewGame()
    {
        score = 0;
        Wizard.stats = new PlayerStats();
        SceneManager.LoadScene("Game");
        state = "Game";
    }
}


public static class StatsManager
{
    public static int Score { get; private set; }

    public static void Initialize()
    {
        Score = 0;
    }

    public static void UpdateScore(int points)
    {
        Score += points;

    }
}