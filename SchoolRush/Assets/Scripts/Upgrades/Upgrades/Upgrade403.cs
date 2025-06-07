public class Upgrade403 : Upgrade {

    private KartController kartController;

    public Upgrade403(KartController kartController) : base("신나", GetDescription())
    {
        this.kartController = kartController;
    }

    private static string GetDescription()
    {
        return $"드리프트를 하지 않아도 부스터가 자동으로 1초에 20%씩 채워집니다.";
    }

    public override void OnPick()
    {
        kartController.EnableBoostAutoRecover();
    }
}
