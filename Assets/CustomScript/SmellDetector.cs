using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SmellDetector : MonoBehaviour
{
    [Tooltip("Drag your 'smell' sound audio clip here.")]
    public AudioClip smellSound;

    [Tooltip("Drag your 'eating' sound audio clip here.")]
    public AudioClip eatingSound;

    private AudioSource audioSource;

    private void Awake()
    {
        // Get the AudioSource on this SmellZone object.
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // --- Logic for whole food ---
        if (other.CompareTag("Food"))
        {
            // Play the smell sound from this object's AudioSource.
            if (smellSound != null && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(smellSound);
            }
        }

        // --- Logic for the picked-up food particle ---
        if (other.CompareTag("FoodParticle"))
        {
            // Only play the eating sound
            if (eatingSound != null)
            {
                audioSource.PlayOneShot(eatingSound);
            }

            // Destroy the food particle after sound plays
            Destroy(other.gameObject);
        }
    }
}
