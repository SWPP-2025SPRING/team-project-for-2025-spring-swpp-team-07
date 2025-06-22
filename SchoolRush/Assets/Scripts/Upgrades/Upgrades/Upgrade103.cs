public class Upgrade103 : Upgrade {

    private SpawnerController sc;

    public Upgrade103(SpawnerController sc): base(103, "통행 금지령") {
        this.sc = sc;
    }

    public override void OnPick()
    {
        sc.StopSpawn();
    }
}
