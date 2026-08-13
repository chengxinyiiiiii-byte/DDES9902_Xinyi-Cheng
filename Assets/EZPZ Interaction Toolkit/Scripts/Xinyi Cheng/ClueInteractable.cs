using UnityEngine;

public class ClueInteractable : MonoBehaviour
{
    public GameObject interactionPrompt;
    public AudioSource clueVoice;

    private bool playerNearby = false;
    private bool investigated = false;

    void Update()
    {
        if (playerNearby && !investigated)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InvestigateClue();
            }
        }
    }

    void InvestigateClue()
    {
        investigated = true;

        if (interactionPrompt != null)
        {
            interactionPrompt.SetActive(false);
        }

        if (clueVoice != null)
        {
            clueVoice.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;

            if (!investigated && interactionPrompt != null)
            {
                interactionPrompt.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;

            if (interactionPrompt != null)
            {
                interactionPrompt.SetActive(false);
            }
        }
    }
}