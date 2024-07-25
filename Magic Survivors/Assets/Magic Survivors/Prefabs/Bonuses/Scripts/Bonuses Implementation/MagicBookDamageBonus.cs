using UnityEngine;

[CreateAssetMenu(fileName = "MagicBookDamageBonus", menuName = "Bonuses/MagicBookDamageBonus")]
public class MagicBookDamageBonus : MagicBookIncreaserBonus
{
    protected override void ChangeStats()
    {
        var stats = _interactor.CurrentStats;
        var standartDamage = _interactor.StandartStats.Damage;

        stats.Damage += (_increaserValue * standartDamage);
        _interactor.SetStats(stats);
    }
}