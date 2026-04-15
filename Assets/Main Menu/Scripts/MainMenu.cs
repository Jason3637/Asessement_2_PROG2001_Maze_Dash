using UnityEngine;
using UnityEngine.SceneManagement; // Required for switching scenes

public class MenuBtn : MonoBehaviour // Change 'MainMenu' to 'MenuBtn'
{
    // These functions must be 'public' to show up in the button settings
    
    public void GoToHome()
    {
        SceneManager.LoadScene("1. Home Scene");
    }

    public void GoToStart()
    {
        SceneManager.LoadScene("2. Jasons Level");
    }

    public void GoToLevels()
    {
        SceneManager.LoadScene("3. Levels Scene");
    }

    public void GoToHelp()
    {
        SceneManager.LoadScene("4. Help Scene");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("5. Credit Scene");
    }

    public void QuitGame()
    {
        Debug.Log("Game Exiting...");
        Application.Quit();
    }
}