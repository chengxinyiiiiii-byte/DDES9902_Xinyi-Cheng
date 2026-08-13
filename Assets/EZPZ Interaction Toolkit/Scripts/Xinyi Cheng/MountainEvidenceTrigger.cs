using UnityEngine;

public class MountainEvidenceTrigger : MonoBehaviour
{
    public GameObject interactionPrompt;
    public AudioSource evidenceVoice;
    public CulpritChoiceManager culpritChoiceManager;

    private bool playerNearby = false;
    private bool investigated = false;

    void Update()
    {
        if (playerNearby && !investigated && Input.GetKeyDown(KeyCode.E))
        {
            investigated = true;

            if (interactionPrompt != null)
            {
                interactionPrompt.SetActive(false);
            }

            if (evidenceVoice != null)
            {
                evidenceVoice.Play();
                Invoke(nameof(ShowChoice), evidenceVoice.clip.length + 0.5f);
            }
            else
            {
                ShowChoice();
            }
        }
    }

    void ShowChoice()
    {
        culpritChoiceManager.ShowChoices();
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