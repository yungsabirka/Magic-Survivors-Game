using UnityEngine;

[CreateAssetMenu(fileName = "HealthBonus", menuName = "Bonuses/HealthBonus")]
public class HealthBonus : Bonus
{
    [SerializeField, Range(0.0f, 1.0f)] private float _maxHealthIncreaserValue = 0.15f;
    [SerializeField, Range(0.1f, 2f)] private float _maxHealthBonus = 1f;

    private float _currentHealthBonus;
    private PlayerInfoInteractor _interactor;

    public override void ResetParameters()
    {
        _currentHealthBonus = 0f;
    }

    public override void ActiveBonus()
    {
        if (_interactor == null)
            _interactor = Game.GetInteractor<PlayerInfoInteractor>();

        var stats = _interactor.CurrentStats;
        var standartMaxHealth = _interactor.StandartStats.MaxHealth;
        _currentHealthBonus += _maxHealthIncreaserValue;
        stats.MaxHealth += (_maxHealthIncreaserValue * standartMaxHealth);

        if (_interactor.CurrentStats.MaxHealth == _interactor.Health)
            _interactor.SetHealth(stats.MaxHealth);
        
        _interactor.SetStats(stats);

        if (_currentHealthBonus >= _maxHealthBonus)
            RemoveBonusFromList();
    }
}