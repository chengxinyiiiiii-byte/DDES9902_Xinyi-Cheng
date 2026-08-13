using UnityEngine;

public class TalkTrigger : MonoBehaviour
{
    public GameObject interactionPrompt;
    public AudioSource motherVoice;

    private bool playerNearby = false;


    void Start()
    {
        interactionPrompt.SetActive(false);
    }


    void Update()
    {
        if (playerNearby)
        {
            interactionPrompt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.P))
            {
                TalkToMother();
            }
        }
        else
        {
            interactionPrompt.SetActive(false);
        }
    }


    void TalkToMother()
    {
        interactionPrompt.SetActive(false);

        if (motherVoice != null)
        {
            motherVoice.Stop();
        }

        Debug.Log("Start talking with Stella's mom");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}