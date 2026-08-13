using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public AudioSource playerNarration;
    public GameObject introGate;

    void Start()
    {
        // Play the player's narration when the game starts
        playerNarration.Play();

        // Remove the gate after the narration finishes
        Invoke("RemoveGate", playerNarration.clip.length);
    }

    void RemoveGate()
    {
        // Open the path by removing the invisible wall
        introGate.SetActive(false);
    }
}