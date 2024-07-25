using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthView : MonoBehaviour, IInitializable
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private RectTransform _healthBarTransform;
    [SerializeField] private RectTransform _redBox;
    [SerializeField] private RectTransform _healthBox;

    private PlayerInfoInteractor _interactor;

    private float _maxWidth = 1000;
    private float _scaleValue = 3.0f;

    public void Initialize()
    {
        _interactor = Game.GetInteractor<PlayerInfoInteractor>();
        _interactor.HealthChanged += ChangeHealthView;
        _interactor.StatsChanged += ChangeMaxHealthView;
    }

    private void OnDestroy()
    {
        if (_interactor == null)
            return;

        _interactor.HealthChanged -= ChangeHealthView;
        _interactor.StatsChanged -= ChangeMaxHealthView;
    }
    private void ChangeHealthView()
    {
        var health = _interactor.Health;
        var maxHealth = _interactor.CurrentStats.MaxHealth;

        _healthBar.fillAmount = health / maxHealth;
    }

    private void ChangeMaxHealthView()
    {
        var maxHealth = _interactor.CurrentStats.MaxHealth;
        var width = maxHealth * _scaleValue;
        if(width > _maxWidth)
            width = _maxWidth;
        
        _healthBox.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        _healthBarTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width - 20);
        _redBox.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width - 20);
    }

}

