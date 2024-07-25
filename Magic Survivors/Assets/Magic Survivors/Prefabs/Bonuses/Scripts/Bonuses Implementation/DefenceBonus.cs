using UnityEngine;

[CreateAssetMenu(fileName = "DefenceBonus", menuName = "Bonuses/DefenceBonus")]
public class DefenceBonus : Bonus
{
    [SerializeField, Range(0.0f, 1.0f)] private float _armorIncreaserValue = 0.05f;
    [SerializeField, Range(0.0f, 1.0f)] private float _maxDefenceBonus = 0.3f;

    private float _currentDefenceBonus;
    private PlayerInfoInteractor _interactor;

    public override void ResetParameters()
    {
        _currentDefenceBonus = 0f;
    }

    public override void ActiveBonus()
    {
        if (_interactor == null)
            _interactor = Game.GetInteractor<PlayerInfoInteractor>();

        var stats = _interactor.CurrentStats;
        var standartArmor = _interactor.StandartStats.Armor;
        _currentDefenceBonus += _armorIncreaserValue;

        stats.Armor += (_armorIncreaserValue * standartArmor);
        _interactor.SetStats(stats);

        if (_currentDefenceBonus >= _maxDefenceBonus)
            RemoveBonusFromList();
    }
}


