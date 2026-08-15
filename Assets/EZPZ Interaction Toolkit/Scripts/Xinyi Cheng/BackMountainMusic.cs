using UnityEngine;

public class BackMountainMusic : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip horrorMusic;

    public float volume = 1f;

    private bool hasPlayed = false;


    private void OnTriggerEnter(Collider other)
    {
        if (hasPlayed)
            return;


        if (other.CompareTag("Player"))
        {
            PlayHorrorMusic();
            hasPlayed = true;
        }
    }


    void PlayHorrorMusic()
    {
        if (musicSource == null || horrorMusic == null)
            return;


        musicSource.clip = horrorMusic;
        musicSource.loop = true;
        musicSource.volume = volume;
        musicSource.Play();
    }
}