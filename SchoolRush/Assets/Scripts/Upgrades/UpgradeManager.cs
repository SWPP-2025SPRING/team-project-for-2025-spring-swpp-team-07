using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    class Upgrade
    {
        public string title;
        public string description;
        public UnityAction action;

        public Upgrade(string title, string description, UnityAction action)
        {
            this.title = title;
            this.description = description;
            this.action = action;
        }
    }

    [SerializeField]
    private GameObject upgradeUI;
    private List<GameObject> upgradeUIItems;

    // Todo: Replace below 5 lines with "private List<List<Upgrade>> upgrades";

    private List<Upgrade> upgrades1;
    private List<Upgrade> upgrades2;
    private List<Upgrade> upgrades3;
    private List<Upgrade> upgrades4;
    private List<Upgrade> upgrades5;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        upgradeUIItems = new List<GameObject>();

        for (int i = 0; i < 3; i++)
        {
            upgradeUIItems.Add(upgradeUI.transform.GetChild(i).gameObject);
        }

        upgrades1 = new List<Upgrade>
        {
            new Upgrade("Max Speed Increase", "Max speed increased by 30%", MaxSpeedIncrease),
            new Upgrade("Acceleration Increase", "Acceleration increased by 30%", AccelerationIncrease),
            new Upgrade("No Passengers", "No Passengers", NoPassengers),
            new Upgrade("Traffic Num Decrease", "Traffic Num Decrease", TrafficNumDecrease),
            new Upgrade("Exempt From Collision", "Exempt From Collision", ExemptFromCollision),
        };
    }

    public void PickUpgrade(int checkpoint)
    {
        upgradeUI.SetActive(true);
        Time.timeScale = 0;

        if (checkpoint == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                int index = Random.Range(0, upgrades1.Count);

                AddUpgrade2UI(upgradeUIItems[i], upgrades1[index]);

                upgrades1.Remove(upgrades1[index]);
            }
        }

    }


    // 1st child: Title
    // 2nd child: Description
    // 3rd child: button, take effect on click
    private void AddUpgrade2UI(GameObject ui, Upgrade upgrade)
    {
        ui.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = upgrade.title;
        ui.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = upgrade.description;
        ui.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.AddListener(upgrade.action);
        ui.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.AddListener(PickComplete);
    }

    private void PickComplete()
    {
        upgradeUI.SetActive(false);
        Time.timeScale = 1;
        ResetButtonEvents();
    }

    private void ResetButtonEvents()
    {
        for (int i = 0; i < 3; i++)
        {
            upgradeUIItems[i].transform.GetChild(2).gameObject
                .GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }


    void MaxSpeedIncrease()
    {
        Debug.Log("Max speed increased by 30%");
    }

    void AccelerationIncrease()
    {
        Debug.Log("Acceleration increased by 30%");
    }

    void NoPassengers()
    {
        Debug.Log("No Passengers");
    }

    void TrafficNumDecrease()
    {
        Debug.Log("Traffic Num Decrease");
    }

    void ExemptFromCollision()
    {
        Debug.Log("Exempt From Collision");
    }

}
