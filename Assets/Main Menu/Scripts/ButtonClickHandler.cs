using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonClickHandler : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioClip clickSound;
    
    [Range(0f, 1f)]
    public float volume = 1.0f;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (clickSound != null)
        {
            /* PlayClipAtPoint creates a temporary audio player in the 3D world.
               This prevents the sound from cutting off when a scene changes
               or when the button is disabled/destroyed.
            */
            AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position, volume);
        }
        else
        {
            Debug.LogWarning($"No clickSound assigned to {gameObject.name}. Please drag an audio clip into the Inspector.");
        }
    }
}