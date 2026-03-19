using UnityEngine;
using System.Collections.Generic;

public class PlateCounter : MonoBehaviour
{
    public int cupcakeCount = 0;

    private HashSet<GameObject> countedCupcakes = new HashSet<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cupcake") && !countedCupcakes.Contains(other.gameObject))
        {
            countedCupcakes.Add(other.gameObject);
            cupcakeCount++;
            Debug.Log(gameObject.name + " now has " + cupcakeCount + " cupcakes");
        }
    }
}