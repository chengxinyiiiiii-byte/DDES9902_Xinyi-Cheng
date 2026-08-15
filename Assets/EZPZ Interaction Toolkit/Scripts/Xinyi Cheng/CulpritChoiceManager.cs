using UnityEngine;

public class CulpritChoiceManager : MonoBehaviour
{
    public GameObject choicePanel;
    public GameObject wrongEndingPanel;
    public GameObject masterLetter;


    public GameEndingManager gameEndingManager;



    void Start()
    {
        if (choicePanel != null)
            choicePanel.SetActive(false);


        if (wrongEndingPanel != null)
            wrongEndingPanel.SetActive(false);


        if (masterLetter != null)
            masterLetter.SetActive(false);
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


        // Correct choice: reveal the letter
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


        if (wrongEndingPanel != null)
        {
            wrongEndingPanel.SetActive(true);
        }


        if (gameEndingManager != null)
        {
            gameEndingManager.ShowMisjudgedEnding();
        }


        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}