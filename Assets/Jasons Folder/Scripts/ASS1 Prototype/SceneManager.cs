using UnityEngine;
using UnityEngine.SceneManagement; // Required for switching scenes

public sealed class SceneManagerScript : MonoBehaviour
{
    // These methods can be called by your UI Buttons
    
    public void LoadHome() => SceneManager.LoadScene("1. Home Scene");
    
    public void LoadStart() => SceneManager.LoadScene("2. Start Scene");
    
    public void LoadLevels() => SceneManager.LoadScene("3. Levels Scene");
    
    public void LoadHelp() => SceneManager.LoadScene("4. Help Scene");
    
    public void LoadCredits() => SceneManager.LoadScene("5. Credit Scene");

    // Useful for a "Quit" button in the Home menu
    public void QuitGame()
    {
        Debug.Log("Quit button pressed!");
        Application.Quit();
    }
}