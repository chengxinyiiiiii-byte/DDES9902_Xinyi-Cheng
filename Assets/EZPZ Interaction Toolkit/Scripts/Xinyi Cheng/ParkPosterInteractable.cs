using UnityEngine;

public class ParkPosterInteractable : MonoBehaviour
{
    public GameObject interactionPrompt;
    public AudioSource clueVoice;

    private bool playerNearby = false;

    void Update()
    {
        if (playerNearby &&
            !ParkPosterManager.posterClueDiscovered &&
            Input.GetKeyDown(KeyCode.E))
        {
            InvestigatePoster();
        }
    }

    void InvestigatePoster()
    {
        ParkPosterManager.posterClueDiscovered = true;

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

            if (!ParkPosterManager.posterClueDiscovered &&
                interactionPrompt != null)
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