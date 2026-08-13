using UnityEngine;

public class ProfessorDialogueTrigger : MonoBehaviour
{
    public AudioSource professorDialogue;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !triggered)
        {
            triggered = true;

            professorDialogue.Play();
        }
    }
}