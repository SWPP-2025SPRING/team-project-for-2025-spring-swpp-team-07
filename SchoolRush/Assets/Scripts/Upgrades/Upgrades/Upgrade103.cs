public class Upgrade103 : Upgrade {

    public Upgrade103() : base("통행 금지령", GetDescription())
    {

    }

    private static string GetDescription()
    {
        return "행인이 더 이상\n등장하지 않습니다.";
    }

    public override void OnPick()
    {
        GameController.Instance.NoMorePassengers();
    }
}
