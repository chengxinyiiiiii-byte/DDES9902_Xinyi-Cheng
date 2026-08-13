using UnityEngine;

public class RescueTrigger : MonoBehaviour
{
    public GameEndingManager gameEndingManager;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;

            if (gameEndingManager != null)
            {
                gameEndingManager.ShowRescuedEnding();
            }
        }
    }
}