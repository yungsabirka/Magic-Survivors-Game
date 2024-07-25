using UnityEngine;

[CreateAssetMenu(fileName = "AttackBonus", menuName = "Bonuses/AttackBonus")]
public class AttackBonus : Bonus
{
    [SerializeField, Range(0.0f, 1.0f)] private float _damageIncreaserValue = 0.1f;

    private PlayerInfoInteractor _interactor;

    public override void ActiveBonus()
    {
        if(_interactor == null)
            _interactor = Game.GetInteractor<PlayerInfoInteractor>();

        var stats = _interactor.CurrentStats;
        var standartDamage = _interactor.StandartStats.WeaponDamage;

        stats.WeaponDamage += (_damageIncreaserValue * standartDamage);
        _interactor.SetStats(stats);
    }
}

