public class Upgrade402 : Upgrade {
    public Upgrade402(): base("축제", GetDescription()) {

    }

    private static string GetDescription() {
        return "배경음악이 축제 노래로 변경됩니다.";
    }

    public override void OnPick()
    {
        UnityEngine.Debug.Log("BGM has been changed");
    }
}
