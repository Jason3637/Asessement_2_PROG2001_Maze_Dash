using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinTrigger : MonoBehaviour
{
    [Header("UI & Delay")]
    public GameObject winPanel; // Your "Congratulations" UI
    public float delayBeforeLoad = 3f;

    [Scene] // Keeps your dropdown functionality
    public string nextScene;

    private bool hasWon = false;

    private void OnTriggerEnter(Collider other)
    {
        // Ensure only the Player triggers the win
        if (other.CompareTag("Player") && !hasWon)
        {
            // Find the timer in your scene
            GameTimer timer = Object.FindFirstObjectByType<GameTimer>();

            // Only win if time is still remaining
            if (timer != null && timer.timeRemaining > 0)
            {
                hasWon = true;
                timer.enabled = false; // Stop the clock immediately
                StartCoroutine(HandleWinSequence());
            }
        }
    }

    IEnumerator HandleWinSequence()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        // Wait so the player can read the message
        yield return new WaitForSeconds(delayBeforeLoad);

        if (!string.IsNullOrEmpty(nextScene))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}