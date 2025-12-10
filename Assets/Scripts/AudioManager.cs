using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlaySFX(AudioClip sfx)
    {
        if (audioSource != null && sfx != null)
        {
            audioSource.PlayOneShot(sfx);
        }
    }
}
