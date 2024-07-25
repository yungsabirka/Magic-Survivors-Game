using UnityEngine;

[CreateAssetMenu(fileName = "MagicBookProjectilesSpeedBonus", menuName = "Bonuses/MagicBookProjectilesSpeedBonus")]
public class MagicBookProjectilesSpeedBonus : MagicBookIncreaserBonus
{
    protected override void ChangeStats()
    {
        var stats = _interactor.CurrentStats;
        var standartSpeed = _interactor.StandartStats.ProjectilesMovingSpeed;

        stats.ProjectilesMovingSpeed += (_increaserValue * standartSpeed);
        _interactor.SetStats(stats);
    }
}