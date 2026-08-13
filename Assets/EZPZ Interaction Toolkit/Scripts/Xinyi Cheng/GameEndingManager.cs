using UnityEngine;
using TMPro;

public class GameEndingManager : MonoBehaviour
{
    [Header("Ending Panels")]
    public GameObject rescuedEndingPanel;
    public GameObject tooLateEndingPanel;

    [Header("Timer UI")]
    public TMP_Text timerText;

    [Header("Game Time")]
    public float totalGameTime = 300f; // 5 real minutes = 24 in-game hours

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

        // Keep TimerText active, but hide the text before the timer starts
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

        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
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