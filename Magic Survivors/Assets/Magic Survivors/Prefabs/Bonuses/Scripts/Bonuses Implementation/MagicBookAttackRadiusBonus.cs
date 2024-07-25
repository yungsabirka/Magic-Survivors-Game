using UnityEngine;

[CreateAssetMenu(fileName = "MagicBookAttackRadiusBonus", menuName = "Bonuses/MagicBookAttackRadiusBonus")]
public class MagicBookAttackRadiusBonus : MagicBookIncreaserBonus
{
    protected override void ChangeStats()
    {
        var stats = _interactor.CurrentStats;
        var standartRadius = _interactor.StandartStats.AttackRadius;

        stats.AttackRadius += (_increaserValue * standartRadius);
        _interactor.SetStats(stats);
    }
}