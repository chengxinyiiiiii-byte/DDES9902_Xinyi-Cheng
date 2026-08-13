using UnityEngine;
using TMPro;

public class MotherDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;

    public AudioSource motherVoice;

    private bool playerNearby = false;
    private bool isTalking = false;


    void Update()
    {
        if(playerNearby && Input.GetKeyDown(KeyCode.E) && !isTalking)
        {
            StartDialogue();
        }
    }


    void StartDialogue()
    {
        isTalking = true;

        // Stop searching voice
        if(motherVoice != null)
        {
            motherVoice.Stop();
        }

        dialoguePanel.SetActive(true);

        dialogueText.text =
        "Please... have you seen my daughter Stella?\n\n" +
        "She disappeared during the Summer Festival.";
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}