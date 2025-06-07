public class Upgrade303 : Upgrade {

    private KartController kartController;
    private readonly static float rate = 2.2f;

    public Upgrade303(KartController kartController) : base("레버리지", GetDescription(kartController))
    {
        this.kartController = kartController;
    }

    private static string GetDescription(KartController kartController)
    {
        float maxSpeed = kartController.GetMaxSpeed();
        return $"최고 속도가 120% 증가하는 대신, 주변 차량과 충돌 시 2초 더 기절합니다.\n\n{maxSpeed} -> {maxSpeed * rate}";
    }

    public override void OnPick()
    {
        kartController.SetMaxSpeed(kartController.GetMaxSpeed() * rate);
    }
}
