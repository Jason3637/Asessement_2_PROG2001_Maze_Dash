using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections; // Required for Coroutines

// This defines the [Scene] label so the error CS0616 goes away
public class SceneAttribute : PropertyAttribute { } 

public class GameTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float timeRemaining = 60f;
    public TextMeshProUGUI timerText;

    [Header("Game Over Settings")]
    public GameObject gameOverPanel; // Drag your UI Panel here
    public float delayBeforeLoad = 3f; // How many seconds to wait

    [Scene] // This creates the dropdown menu (if SceneDrawer.cs exists)
    public string destinationScene;

    private bool isLevelEnding = false;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else if (!isLevelEnding)
        {
            isLevelEnding = true;
            StartCoroutine(HandleGameOver());
        }
    }

    IEnumerator HandleGameOver()
    {
        // 1. Force clock to zero and update UI
        timeRemaining = 0;
        DisplayTime(0);

        // 2. Show the "You Lose" UI
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Game Over Panel is not assigned in the Inspector!");
        }

        // 3. Wait while the player looks at the "You Lose" message
        yield return new WaitForSeconds(delayBeforeLoad);

        // 4. Load the next scene
        if (!string.IsNullOrEmpty(destinationScene))
        {
            SceneManager.LoadScene(destinationScene);
        }
        else
        {
            Debug.LogError("No destination scene selected in the Inspector!");
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float t = Mathf.Max(0, timeToDisplay);
        float minutes = Mathf.FloorToInt(t / 60); 
        float seconds = Mathf.FloorToInt(t % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}