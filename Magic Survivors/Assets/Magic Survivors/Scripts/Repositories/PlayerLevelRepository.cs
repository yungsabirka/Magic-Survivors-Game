
public class PlayerLevelRepository : Repository
{
    public int Level { get; set; }
    public float NextLevelAmount { get; set; }
    public float CurrentLevelAmount { get; set; }

    public override void Initialize()
    {
        Level = 0;
        NextLevelAmount = 100;
        CurrentLevelAmount = 0;
    }
}

