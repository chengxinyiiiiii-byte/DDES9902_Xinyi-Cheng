using UnityEngine;
using TMPro;
using System.Collections;

public class GameEndingManager : MonoBehaviour
{
    [Header("Ending Panels")]
    public GameObject rescuedEndingPanel;
    public GameObject tooLateEndingPanel;
    public GameObject misjudgedEndingPanel;


    [Header("Timer UI")]
    public TMP_Text timerText;


    [Header("Game Time Settings")]
    public float totalGameTime = 300f;

    // 300 real seconds = 24 in-game hours
    // 12.5 real seconds = 1 in-game hour
    // Start at 18:00



    [Header("Music Settings")]
    public AudioSource musicSource;

    public AudioClip communityMusic;
    public AudioClip investigationMusic;
    public AudioClip horrorMusic;

    public AudioClip rescuedEndingMusic;
    public AudioClip tooLateEndingMusic;
    public AudioClip misjudgedEndingMusic;


    public float musicVolume = 1f;

    public float fadeDuration = 2f;



    private Coroutine musicCoroutine;


    private float remainingTime;
    private bool timerRunning = false;
    private bool gameEnded = false;





    void Start()
    {
        Time.timeScale = 1f;

        remainingTime = totalGameTime;



        if (rescuedEndingPanel != null)
            rescuedEndingPanel.SetActive(false);


        if (tooLateEndingPanel != null)
            tooLateEndingPanel.SetActive(false);


        if (misjudgedEndingPanel != null)
            misjudgedEndingPanel.SetActive(false);



        if (timerText != null)
        {
            timerText.gameObject.SetActive(true);
            timerText.text = "";
        }



        // Start Community Music
        PlayMusic(communityMusic);
    }






    void Update()
    {
        if (!timerRunning || gameEnded)
            return;



        remainingTime -= Time.unscaledDeltaTime;



        if (remainingTime <= 0f)
        {
            remainingTime = 0f;

            UpdateTimerText();

            ShowTooLateEnding();

            return;
        }


        UpdateTimerText();
    }






    public void StartTimer()
    {
        Time.timeScale = 1f;


        remainingTime = totalGameTime;


        timerRunning = true;


        gameEnded = false;



        // Community -> Investigation
        PlayMusic(investigationMusic);



        UpdateTimerText();


        Debug.Log("GAME TIMER STARTED");
    }







    void UpdateTimerText()
    {
        if (timerText == null)
            return;



        float elapsedTime = totalGameTime - remainingTime;


        float gameHoursPassed = elapsedTime / 12.5f;


        float currentGameHour = 18f + gameHoursPassed;



        if (currentGameHour >= 24f)
        {
            currentGameHour -= 24f;
        }



        int hour = Mathf.FloorToInt(currentGameHour);



        timerText.text = string.Format(
            "{0:00}:00",
            hour
        );
    }








    // Back Mountain Trigger
    public void PlayHorrorMusic()
    {
        PlayMusic(horrorMusic);
    }







    // Wrong culprit choice
    public void PlayMisjudgedMusic()
    {
        PlayMusic(misjudgedEndingMusic);
    }







    public void ShowRescuedEnding()
    {
        if (gameEnded)
            return;



        gameEnded = true;

        timerRunning = false;



        PlayMusic(rescuedEndingMusic);



        if (timerText != null)
            timerText.text = "";



        if (tooLateEndingPanel != null)
            tooLateEndingPanel.SetActive(false);


        if (misjudgedEndingPanel != null)
            misjudgedEndingPanel.SetActive(false);



        if (rescuedEndingPanel != null)
            rescuedEndingPanel.SetActive(true);



        Cursor.lockState = CursorLockMode.None;

        Cursor.visible = true;



        Time.timeScale = 0f;
    }








    public void ShowTooLateEnding()
    {
        if (gameEnded)
            return;



        gameEnded = true;

        timerRunning = false;



        PlayMusic(tooLateEndingMusic);



        if (timerText != null)
            timerText.text = "";



        if (rescuedEndingPanel != null)
            rescuedEndingPanel.SetActive(false);


        if (misjudgedEndingPanel != null)
            misjudgedEndingPanel.SetActive(false);



        if (tooLateEndingPanel != null)
            tooLateEndingPanel.SetActive(true);



        Cursor.lockState = CursorLockMode.None;

        Cursor.visible = true;



        Time.timeScale = 0f;
    }








    public void ShowMisjudgedEnding()
    {
        if (gameEnded)
            return;



        gameEnded = true;

        timerRunning = false;



        PlayMusic(misjudgedEndingMusic);



        if (timerText != null)
            timerText.text = "";



        if (rescuedEndingPanel != null)
            rescuedEndingPanel.SetActive(false);


        if (tooLateEndingPanel != null)
            tooLateEndingPanel.SetActive(false);



        if (misjudgedEndingPanel != null)
            misjudgedEndingPanel.SetActive(true);



        Cursor.lockState = CursorLockMode.None;

        Cursor.visible = true;



        Time.timeScale = 0f;
    }








    void PlayMusic(AudioClip music)
    {
        if (musicSource == null || music == null)
            return;



        if (musicCoroutine != null)
        {
            StopCoroutine(musicCoroutine);
        }


        musicCoroutine = StartCoroutine(ChangeMusic(music));
    }








    IEnumerator ChangeMusic(AudioClip newMusic)
    {
        // Fade out current music

        while (musicSource.volume > 0f)
        {
            musicSource.volume -= Time.unscaledDeltaTime / fadeDuration;

            yield return null;
        }



        musicSource.Stop();



        // Switch music

        musicSource.clip = newMusic;

        musicSource.loop = true;

        musicSource.volume = 0f;

        musicSource.Play();





        // Fade in new music

        while (musicSource.volume < musicVolume)
        {
            musicSource.volume += Time.unscaledDeltaTime / fadeDuration;

            yield return null;
        }



        musicSource.volume = musicVolume;
    }







    public float GetRemainingTime()
    {
        return remainingTime;
    }
}