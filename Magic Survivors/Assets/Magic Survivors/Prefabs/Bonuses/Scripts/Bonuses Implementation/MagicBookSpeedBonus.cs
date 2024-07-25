using UnityEngine;

[CreateAssetMenu(fileName = "MagicBookSpeedBonus", menuName = "Bonuses/MagicBookSpeedBonus")]
public class MagicBookSpeedBonus : MagicBookIncreaserBonus
{
    protected override void ChangeStats()
    {
        var stats = _interactor.CurrentStats;
        var standartSpeed = _interactor.StandartStats.MagixBookMovingSpeed;

        stats.MagixBookMovingSpeed += (_increaserValue * standartSpeed);
        _interactor.SetStats(stats);
    }
}