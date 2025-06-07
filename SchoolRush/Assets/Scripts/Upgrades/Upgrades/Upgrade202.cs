public class Upgrade202 : Upgrade {
    private KartController kartController;
    private readonly static float rate = 1.3f;

    public Upgrade202(KartController kartController) : base("가속도 증가", GetDescription(kartController))
    {
        this.kartController = kartController;
    }

    private static string GetDescription(KartController kartController)
    {
        float acc = kartController.GetAcceleration();
        return $"가속도가\n50% 증가합니다.\n\n{acc} -> {acc * rate}";
    }

    public override void OnPick()
    {
        kartController.SetAcceleration(kartController.GetAcceleration() * rate);
    }
}
