using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public AudioSource narration;
    public GameObject invisibleWall;

    void Start()
    {
        narration.Play();

        Invoke("OpenGate", narration.clip.length);
    }

    void OpenGate()
    {
        invisibleWall.SetActive(false);
    }
}