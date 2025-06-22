using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public void StopSpawn()
    {
        var passengers = GameObject.FindGameObjectsWithTag("Passenger");

        foreach (GameObject a in passengers)
        {
            a.Destroy();
        }

        gameObject.Destroy();
    }
}
