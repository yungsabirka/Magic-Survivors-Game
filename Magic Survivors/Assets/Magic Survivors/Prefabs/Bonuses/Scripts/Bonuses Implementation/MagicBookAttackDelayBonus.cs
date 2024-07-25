using UnityEngine;

[CreateAssetMenu(fileName = "MagicBookAttackDelayBonus", menuName = "Bonuses/MagicBookAttackDelayBonus")]
public class MagicBookAttackDelayBonus : MagicBookIncreaserBonus
{
    protected override void ChangeStats()
    {
        var stats = _interactor.CurrentStats;
        var standartDelay = _interactor.StandartStats.AttackDelayInSeconds;

        stats.AttackDelayInSeconds -= (_increaserValue * standartDelay);
        _interactor.SetStats(stats);
    }
}