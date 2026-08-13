using UnityEngine;

public class ProfessorDoorDialogue : MonoBehaviour
{
    public AudioSource doorDialogue;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !triggered)
        {
            triggered = true;

            doorDialogue.Play();
        }
    }
}