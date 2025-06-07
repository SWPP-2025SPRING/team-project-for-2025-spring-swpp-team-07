using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public bool IsNoPassengers { get; private set; }
    public bool IsTrafficSpawnRateReducedByHalf {  get; set; }
    public bool IsNoTraffic {  get; set; }

    private List<GameObject> passengerSpawners;

    private void Awake()
    {
        Instance = this;

        passengerSpawners = new List<GameObject>();
    }

    public void AddPassengerSpawner(GameObject ps)
    {
        passengerSpawners.Add(ps);
    }

    public void NoMorePassengers()
    {
        if (IsNoPassengers) return;

        foreach(GameObject passenger in passengerSpawners)
        {
            Destroy(passenger);
        }

        IsNoPassengers = true;
    }

}
