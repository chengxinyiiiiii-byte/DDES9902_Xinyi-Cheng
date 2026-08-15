using UnityEngine;
using TMPro;

public class GameEndingManager : MonoBehaviour
{
    [Header("Ending Panels")]
    public GameObject rescuedEndingPanel;
    public GameObject tooLateEndingPanel;


    [Header("Timer UI")]
    public TMP_Text timerText;


    [Header("Game Time Settings")]
    public float totalGameTime = 300f;
    
    // 300 real seconds = 24 in-game hours
    // 12.5 real seconds = 1 in-game hour
    // Game starts at 18:00


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


        if (timerText != null)
        {
            timerText.gameObject.SetActive(true);
            timerText.text = "";
        }
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


        UpdateTimerText();


        Debug.Log("GAME TIMER STARTED");
    }





    void UpdateTimerText()
    {
        if (timerText == null)
            return;


        // Calculate elapsed real time
        float elapsedTime = totalGameTime - remainingTime;


        // Convert real seconds into in-game hours
        // 12.5 seconds = 1 in-game hour
        float gameHoursPassed = elapsedTime / 12.5f;


        // Start from 18:00
        float currentGameHour = 18f + gameHoursPassed;


        // Convert after midnight
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





    public void ShowRescuedEnding()
    {
        if (gameEnded)
            return;


        gameEnded = true;

        timerRunning = false;


        if (timerText != null)
            timerText.text = "";


        if (tooLateEndingPanel != null)
            tooLateEndingPanel.SetActive(false);


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


        if (timerText != null)
            timerText.text = "";


        if (rescuedEndingPanel != null)
            rescuedEndingPanel.SetActive(false);


        if (tooLateEndingPanel != null)
            tooLateEndingPanel.SetActive(true);



        Cursor.lockState = CursorLockMode.None;

        Cursor.visible = true;


        Time.timeScale = 0f;
    }





    public float GetRemainingTime()
    {
        return remainingTime;
    }
}