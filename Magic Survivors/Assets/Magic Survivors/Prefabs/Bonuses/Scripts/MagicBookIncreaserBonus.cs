using UnityEngine;

public abstract class MagicBookIncreaserBonus : Bonus
{
    [SerializeField, Range(0.0f, 1.0f)] protected float _increaserValue;
    [SerializeField, Range(0.0f, 1.5f)] protected float _maxIncreaserBonus;

    protected float _currentBonus;

    protected MagixBookInteractor _interactor;

    public override void ResetParameters()
    {
        _currentBonus = 0.0f;
    }
    public override void ActiveBonus()
    {
        if (_interactor == null)
            _interactor = Game.GetInteractor<MagixBookInteractor>();

        ChangeStats();

        _currentBonus += _increaserValue;
        if (_currentBonus >= _maxIncreaserBonus)
            RemoveBonusFromList();
    }

    protected abstract void ChangeStats();
}