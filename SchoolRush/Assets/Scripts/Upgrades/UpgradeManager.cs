using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public KartController kartController;

    [SerializeField]
    private GameObject upgradeUI;
    private List<GameObject> upgradeUIItems;

    private List<Upgrade> selectedUpgrades;

    private void Start() {
        upgradeUIItems = new List<GameObject>();
        selectedUpgrades = new List<Upgrade>();

        for (int i = 0; i < 3; i++)
            upgradeUIItems.Add(upgradeUI.transform.GetChild(i).gameObject);
    }

    public void PickUpgrade(int checkpoint) {
        upgradeUI.SetActive(true);
        Time.timeScale = 0;
        List<Upgrade> upgrades = new List<Upgrade>(); // should be length 3

        switch (checkpoint) {
            case 1:
                Upgrade u101 = new Upgrade101(kartController);
                Upgrade u102 = new Upgrade102(kartController);
                Upgrade u103 = new Upgrade103();
                Upgrade u104 = new Upgrade104();
                Upgrade u105 = new Upgrade105(kartController);
                upgrades.AddRange(GetRandom(new List<Upgrade> { u101, u102, u103, u104, u105 }, 3));
                break;
            case 2:
                Upgrade u201 = new Upgrade201(kartController);
                Upgrade u202 = new Upgrade202(kartController);
                Upgrade u203 = new Upgrade203(kartController);
                Upgrade u204 = new Upgrade204();
                Upgrade u205 = new Upgrade205(kartController);
                upgrades.AddRange(GetRandom(new List<Upgrade> { u201, u202, u203, u204, u205 }, 3));
                break;
            case 3:
                Upgrade u301 = new Upgrade301(kartController);
                Upgrade u302 = new Upgrade302(kartController);
                Upgrade u303 = new Upgrade303(kartController);
                upgrades.AddRange(GetRandom(new List<Upgrade> { u301, u302, u303 }, 3));
                break;
            case 4:
                Upgrade u401 = new Upgrade401(kartController);
                Upgrade u402 = new Upgrade402();
                Upgrade u403 = new Upgrade403(kartController);
                Upgrade u404 = new Upgrade404();
                upgrades.AddRange(GetRandom(new List<Upgrade> { u401, u402, u403, u404 }, 3));
                break;
            case 5:
                break;
        }

        foreach (var upgrade in upgrades) {
            int index = upgrades.IndexOf(upgrade);
            upgradeUIItems[index].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = upgrade.GetTitle();
            upgradeUIItems[index].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = upgrade.GetDescription();
            upgradeUIItems[index].transform.GetChild(2).gameObject.GetComponent<Button>().onClick.AddListener(() => PickComplete(upgrade));
            upgradeUIItems[index].SetActive(true);
        }
    }

    private void PickComplete(Upgrade upgrade)
    {
        upgradeUI.SetActive(false);
        upgrade.OnPick();
        Time.timeScale = 1;
        selectedUpgrades.Add(upgrade);

        foreach (var item in upgradeUIItems)
            item.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private List<Upgrade> GetRandom(List<Upgrade> upgrades, int count) {
      List<Upgrade> upgradeList = new List<Upgrade>(upgrades);
      List<Upgrade> selectedUpgrades = new List<Upgrade>();

      System.Random random = new System.Random();

      int remainingCount = Mathf.Min(count, upgradeList.Count);

      while (remainingCount > 0 && upgradeList.Count > 0)
      {
          int randomIndex = random.Next(0, upgradeList.Count);
          selectedUpgrades.Add(upgradeList[randomIndex]);
          upgradeList.RemoveAt(randomIndex);
          remainingCount--;
      }

      return selectedUpgrades;
    }
}
