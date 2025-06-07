public class Upgrade205 : Upgrade {

    private KartController kartController;

    public Upgrade205(KartController kartController) : base("스프링", GetDescription(kartController)) {
        this.kartController = kartController;
    }

    private static string GetDescription(KartController kartController) {
        return "이제 스페이스바를 누르면 위로 10m 점프합니다. 5초에 한 번만 사용할 수 있습니다.";
    }

    public override void OnPick()
    {
        kartController.EnableJump();
    }
}
