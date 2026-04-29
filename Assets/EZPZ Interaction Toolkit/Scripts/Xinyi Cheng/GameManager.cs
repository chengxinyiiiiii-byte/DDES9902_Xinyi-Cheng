using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;

    public PlateCounter plateMia;
    public PlateCounter plateLeo;
    public PlateCounter plateCecilia;
    public PlateCounter platePlayer;

    public TMP_Text boardText;

    void Start()
    {
        gameStarted = false;

        if (boardText != null)
        {
            boardText.text =
                "Welcome to the birthday party!\n\n" +
                "Click START first to begin the game.\n\n" +
                "After the game starts, you can share the cupcakes with everyone.";
        }
    }

    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.F) && boardText != null)
            {
                boardText.text =
                    "Not yet!\n\n" +
                    "Please click START first.\n\n" +
                    "Then you can share the cupcakes and check your answer.";
            }

            return;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            CheckResult();
        }
    }

    public void StartGame()
    {
        gameStarted = true;

        if (boardText != null)
        {
            boardText.text =
                "Let's share the cupcakes!\n\n" +
                "Mia: \"I'm really hungry. I want about 1/2 of the cupcakes.\"\n\n" +
                "Leo: \"I only need a small part.\"\n\n" +
                "Cecilia: \"I'll have the same as Leo.\"\n\n" +
                "Remember to keep a share for yourself too!\n\n" +
                "Think about the whole group before you share.\n\n" +
                "Press F to check your answer.";
        }

        Debug.Log("Game Started!");
    }

    void CheckResult()
    {
        if (plateMia == null || plateLeo == null || plateCecilia == null || platePlayer == null || boardText == null)
        {
            Debug.LogError("GameManager is missing references. Please assign all plate counters and boardText in the Inspector.");
            return;
        }

        if (plateMia.cupcakeCount == 3 &&
            plateLeo.cupcakeCount == 1 &&
            plateCecilia.cupcakeCount == 1 &&
            platePlayer.cupcakeCount == 1)
        {
            boardText.text =
                "Great sharing!\n\n" +
                "Mia has a big share because she was very hungry.\n\n" +
                "Leo and Cecilia have small equal shares.\n\n" +
                "You also remembered to keep one for yourself.\n\n" +
                "Everyone is happy!";
        }
        else
        {
            string miaHint;
            string leoHint;
            string ceciliaHint;
            string playerHint;

            if (plateMia.cupcakeCount < 3)
            {
                miaHint = "Mia still needs a bigger share.";
            }
            else if (plateMia.cupcakeCount > 3)
            {
                miaHint = "Mia has more than she needs.";
            }
            else
            {
                miaHint = "Mia's share looks good.";
            }

            if (plateLeo.cupcakeCount == 0)
            {
                leoHint = "Leo still needs a small share.";
            }
            else if (plateLeo.cupcakeCount == 1)
            {
                leoHint = "Leo's share looks good.";
            }
            else
            {
                leoHint = "Leo has more than a small share.";
            }

            if (plateCecilia.cupcakeCount == 0)
            {
                ceciliaHint = "Cecilia still needs a small share.";
            }
            else if (plateCecilia.cupcakeCount == 1)
            {
                ceciliaHint = "Cecilia's share looks good.";
            }
            else
            {
                ceciliaHint = "Cecilia has more than a small share.";
            }

            if (platePlayer.cupcakeCount == 0)
            {
                playerHint = "Do not forget to keep one for yourself.";
            }
            else if (platePlayer.cupcakeCount == 1)
            {
                playerHint = "Your share looks good.";
            }
            else
            {
                playerHint = "You have more than one share.";
            }

            boardText.text =
                "Almost there!\n\n" +
                "Think about the whole group again.\n\n" +
                miaHint + "\n" +
                leoHint + "\n" +
                ceciliaHint + "\n" +
                playerHint + "\n\n" +
                "Try again, then press F to check.";
        }
    }
}