using UnityEngine;

[CreateAssetMenu(fileName = "TridentAngularSpeedBonus", menuName = "Bonuses/TridentAngularSpeedBonus")]
public class TridentAngularSpeedBonus : TridentsIncreaserBonus
{
    protected override void ChangeStats()
    {
        var newAngularSpeed = _interactor.AngularSpeed +
            _interactor.StandartAngularSpeed * _increaserValue;

        _currentBonus += _increaserValue;

        _interactor.ChangeAngularSpeed(newAngularSpeed);
    }
}