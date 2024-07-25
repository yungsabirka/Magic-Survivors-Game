using UnityEngine;

[CreateAssetMenu(fileName = "TridentDamageBonus", menuName = "Bonuses/TridentDamageBonus")]
public class TridentDamageBonus : TridentsIncreaserBonus
{
    protected override void ChangeStats()
    {
        var newDamage = _interactor.Damage + _interactor.StandartDamage * _increaserValue;
        _currentBonus += _increaserValue;

        _interactor.ChangeDamage(newDamage);
    }
}