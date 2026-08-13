using UnityEngine;

public class StellaVoiceTrigger : MonoBehaviour
{
    public AudioSource searchingVoice;

    private bool played = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !played)
        {
            played = true;

            searchingVoice.Play();
        }
    }
}