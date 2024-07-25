using UnityEngine;

[CreateAssetMenu(fileName = "HealBonus", menuName = "Bonuses/HealBonus")]
public class HealBonus : Bonus
{
    [SerializeField, Range(0.0f, 1.0f)] private float _healValue = 0.2f;

    private PlayerInfoInteractor _interactor;

    public override void ActiveBonus()
    {
        if (_interactor == null)
            _interactor = Game.GetInteractor<PlayerInfoInteractor>();

        var health = _interactor.Health;
        health += (health * _healValue);

        if(health > _interactor.CurrentStats.MaxHealth)
            health = _interactor.CurrentStats.MaxHealth;

        _interactor.SetHealth(health);
    }
}