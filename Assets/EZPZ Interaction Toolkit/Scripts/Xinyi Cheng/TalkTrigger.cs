using UnityEngine;

public class MotherDialogue : MonoBehaviour
{
    public AudioSource searchingVoice;
    public AudioSource motherDialogue;
    public AudioSource timeNarration;

    private bool triggered = false;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !triggered)
        {
            triggered = true;

            searchingVoice.Stop();

            motherDialogue.Play();

            Invoke("PlayTimeNarration", motherDialogue.clip.length + 1.5f);
        }
    }


    void PlayTimeNarration()
    {
        timeNarration.Play();
    }
}