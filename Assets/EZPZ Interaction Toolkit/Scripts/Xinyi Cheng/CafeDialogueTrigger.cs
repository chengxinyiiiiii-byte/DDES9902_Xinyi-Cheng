using UnityEngine;

public class CafeDialogueTrigger : MonoBehaviour
{
    public AudioSource cafeDialogueVoice;

    private bool triggered = false;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !triggered)
        {
            triggered = true;

            cafeDialogueVoice.Play();
        }
    }
}