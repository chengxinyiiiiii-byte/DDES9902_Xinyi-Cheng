using UnityEngine;

public class StartButtonClick : MonoBehaviour
{
    public GameObject rulePanel;
    public GameObject titleText;
    public GameObject ruleText;
    public GameObject startText;

    public GameManager gameManager; // 控制游戏状态

    private void OnMouseDown()
    {
        // Hide UI
        if (rulePanel != null) rulePanel.SetActive(false);
        if (titleText != null) titleText.SetActive(false);
        if (ruleText != null) ruleText.SetActive(false);
        if (startText != null) startText.SetActive(false);

        gameObject.SetActive(false);

        // Start the game
        if (gameManager != null)
        {
            gameManager.StartGame();
        }
    }
}