using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource musicAudioSource;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        musicAudioSource = GetComponent<AudioSource>();
    }

    // Function to toggle mute/unmute
    public void ToggleMute()
    {
        // Check if the AudioSource component exists
        if (musicAudioSource != null)
        {
            // Toggle the mute state
            musicAudioSource.mute = !musicAudioSource.mute;
        }
    }
}
