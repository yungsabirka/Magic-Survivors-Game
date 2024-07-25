using UnityEngine;

[CreateAssetMenu(fileName = "SpeedBonus", menuName = "Bonuses/SpeedBonus")]
public class SpeedBonus : Bonus
{
    [SerializeField, Range(0.0f, 1.0f)] private float _speedIncreaserValue = 0.1f;
    [SerializeField, Range(0.0f, 1.0f)] private float _maxSpeedBonus = 0.3f;

    private float _currentSpeedBonus;
    private PlayerInfoInteractor _interactor;

    public override void ResetParameters()
    {
        _currentSpeedBonus = 0f;
    }

    public override void ActiveBonus()
    {
        if (_interactor == null)
            _interactor = Game.GetInteractor<PlayerInfoInteractor>();

        var stats = _interactor.CurrentStats;
        var standartSpeed = _interactor.StandartStats.Speed;
        _currentSpeedBonus += _speedIncreaserValue;

        stats.Speed += (_speedIncreaserValue * standartSpeed);
        _interactor.SetStats(stats);

        if (_currentSpeedBonus >= _maxSpeedBonus)
            RemoveBonusFromList();
    }
}