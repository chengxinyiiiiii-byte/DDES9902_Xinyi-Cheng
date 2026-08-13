using UnityEngine;

public class MotherDialogue : MonoBehaviour
{
    public AudioSource searchingVoice;
    public AudioSource dialogueVoice;

    private bool triggered = false;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !triggered)
        {
            triggered = true;


            // Stop Stella searching voice
            if(searchingVoice != null)
            {
                searchingVoice.Stop();
            }


            // Play mother dialogue
            if(dialogueVoice != null)
            {
                dialogueVoice.Play();
            }
        }
    }
}