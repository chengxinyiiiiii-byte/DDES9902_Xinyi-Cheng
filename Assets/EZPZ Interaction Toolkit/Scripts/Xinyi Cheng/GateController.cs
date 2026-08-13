using UnityEngine;

public class GateController : MonoBehaviour
{
    public GameObject gate;

    public void OpenGate()
    {
        gate.SetActive(false);
    }
}