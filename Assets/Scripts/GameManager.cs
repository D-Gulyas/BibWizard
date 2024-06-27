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

            // Nur beim ersten Mal das Game Objekt zu den nicht zerstörbaren Objekten hinzufügen
            if (!isInitialized)
            {
                isInitialized = true;
                // Hier könnten weitere Initialisierungen erfolgen

                // Beispiel für das Speichern von Stats in einer statischen Variable
                StatsManager.Initialize(); // Initialisierung der Stats, falls benötigt
            }
            else
            {
                // Wenn bereits ein Instance vorhanden ist, das neu erstellte GameManager zerstören
                Destroy(gameObject);
                return;
            }
        }
        else
        {
            // Wenn bereits ein GameManager existiert, das neu erstellte GameManager zerstören
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
                    pause.SetActive(true);
                    Time.timeScale = 0f;
                }
                // pause.SetActive(!pause.activeSelf); -- Andere Schreibweise bzw. kürzere Schreibweise 
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

// Beispiel für eine separate StatsManager Klasse zur Verwaltung der Stats
public static class StatsManager
{
    public static int Score { get; private set; }

    public static void Initialize()
    {
        // Hier können Stats initialisiert werden, z.B. von einem Speicher geladen oder auf Standardwerte gesetzt
        Score = 0;
    }

    public static void UpdateScore(int points)
    {
        Score += points;
        // Hier könnten weitere Logiken zur Aktualisierung der Stats erfolgen
    }
}