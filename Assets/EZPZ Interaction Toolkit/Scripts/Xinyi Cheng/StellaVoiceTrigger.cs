using UnityEngine;

public class StellaVoiceTrigger : MonoBehaviour
{
    public AudioSource motherVoice;

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !hasPlayed)
        {
            motherVoice.Play();
            hasPlayed = true;
        }
    }
}