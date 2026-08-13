using UnityEngine;

public class CulpritChoiceManager : MonoBehaviour
{
    public GameObject choicePanel;
    public GameObject wrongEndingPanel;
    public GameObject masterLetter;

    void Start()
    {
        if (choicePanel != null)
        {
            choicePanel.SetActive(false);
        }

        if (wrongEndingPanel != null)
        {
            wrongEndingPanel.SetActive(false);
        }

        if (masterLetter != null)
        {
            masterLetter.SetActive(false);
        }
    }

    public void ShowChoices()
    {
        choicePanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ChooseProfessor()
    {
        ShowWrongEnding();
    }

    public void ChooseCafeOwner()
    {
        ShowWrongEnding();
    }

    public void ChooseMaintenanceWorker()
    {
        choicePanel.SetActive(false);

        if (masterLetter != null)
        {
            masterLetter.SetActive(true);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void ShowWrongEnding()
    {
        choicePanel.SetActive(false);
        wrongEndingPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
    }
}