using UnityEngine;
using UnityEngine.UI; // Optional: for changing the button image later

public class MusicController : MonoBehaviour
{
    // These are the public fields you linked in the Inspector.
    public AudioSource softPianoSource;
    public AudioSource rainAmbientSource; 

    // A simple state flag for the button icon change
    private bool isMusicOn = true; 

    void Start()
    {
        // Start the music automatically when the scene loads
        // We only play if the sources are assigned (not null)
        if (softPianoSource != null) softPianoSource.Play();
        if (rainAmbientSource != null) rainAmbientSource.Play(); 
    }

    // This method is called when the Music Button is clicked
    public void ToggleMusic()
    {
        // 1. Flip the state
        isMusicOn = !isMusicOn;

        if (isMusicOn)
        {
            // 2. Turn music ON (Play)
            
            // Check if the source is valid, and then play the piano
            if (softPianoSource != null) softPianoSource.Play();
            
            // **CRITICAL:** Check if the source is valid, and then play the rain
            if (rainAmbientSource != null) rainAmbientSource.Play(); 
        }
        else
        {
            // 3. Turn music OFF (Pause)
            
            // Check if the source is valid, and then pause the piano
            if (softPianoSource != null) softPianoSource.Pause();
            
            // **CRITICAL:** Check if the source is valid, and then pause the rain
            if (rainAmbientSource != null) rainAmbientSource.Pause(); 
        }
        
        // No need to worry about the optional button icon change logic here.
    }
}