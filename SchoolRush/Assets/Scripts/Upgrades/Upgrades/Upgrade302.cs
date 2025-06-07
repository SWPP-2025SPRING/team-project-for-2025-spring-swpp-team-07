using System.Collections.Generic;
using UnityEngine;

public class Upgrade302 : Upgrade {

    private KartController kartController;
    private readonly static List<float> rates = new() { 1.2f, 1.5f, 2.0f };

    public Upgrade302(KartController kartController) : base("창업", GetDescription(kartController))
    {
        this.kartController = kartController;
    }

    private static string GetDescription(KartController kartController)
    {
        float maxSpeed = kartController.GetMaxSpeed();
        return $"최고 속도가 20% 또는 60% 또는 100% 증가합니다.\n\n{maxSpeed} -> ?";
    }

    public override void OnPick()
    {
        int index = Random.Range(0, rates.Count);

        kartController.SetMaxSpeed(kartController.GetMaxSpeed() * rates[index]);

        Debug.Log($"Max speed increased by: {Mathf.Round((rates[index] - 1) * 100)} %");
    }
}
