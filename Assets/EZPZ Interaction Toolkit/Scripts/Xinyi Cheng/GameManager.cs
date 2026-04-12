using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlateCounter plateMia;
    public PlateCounter plateLeo;
    public PlateCounter plateCecilia;
    public PlateCounter platePlayer;

    public TMP_Text boardText;

    void Start()
    {
        if (boardText != null)
        {
            boardText.text =
                "Mia: I'm really hungry...\n\n" +
                "Leo: Just a small piece is fine.\n" +
                "Cecilia: Me too, just a little is enough.\n\n" +
                "Don't forget yourself.\n\n" +
                "Have you shared fairly? Press F to find out.";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CheckResult();
        }
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
                "Mia: Thank you! That helps a lot.\n\n" +
                "Leo: Perfect for me.\n" +
                "Cecilia: That's just right.\n\n" +
                "You: I have my share too.";
        }
        else
        {
            string miaFeedback;
            string leoFeedback;
            string ceciliaFeedback;
            string playerFeedback;

            // Mia feedback
            if (plateMia.cupcakeCount < 3)
            {
                miaFeedback = "Mia: I'm still hungry...";
            }
            else if (plateMia.cupcakeCount > 3)
            {
                miaFeedback = "Mia: That's more than I need.";
            }
            else
            {
                miaFeedback = "Mia: Mine is fine.";
            }

            // Leo feedback
            if (plateLeo.cupcakeCount == 0)
            {
                leoFeedback = "Leo: I didn't get any.";
            }
            else if (plateLeo.cupcakeCount == 1)
            {
                leoFeedback = "Leo: Mine is fine.";
            }
            else
            {
                leoFeedback = "Leo: That's too much for me.";
            }

            // Cecilia feedback
            if (plateCecilia.cupcakeCount == 0)
            {
                ceciliaFeedback = "Cecilia: I didn't get any.";
            }
            else if (plateCecilia.cupcakeCount == 1)
            {
                ceciliaFeedback = "Cecilia: Mine is fine.";
            }
            else
            {
                ceciliaFeedback = "Cecilia: That's too much for me.";
            }

            // Player feedback
            if (platePlayer.cupcakeCount == 0)
            {
                playerFeedback = "You: Wait... did I forget myself?";
            }
            else if (platePlayer.cupcakeCount == 1)
            {
                playerFeedback = "You: I have my share.";
            }
            else
            {
                playerFeedback = "You: That's more than I need.";
            }

            boardText.text =
                miaFeedback + "\n\n" +
                leoFeedback + "\n" +
                ceciliaFeedback + "\n\n" +
                playerFeedback + "\n\n" +
                "Try again. Press F to recheck.";
        }
    }
}