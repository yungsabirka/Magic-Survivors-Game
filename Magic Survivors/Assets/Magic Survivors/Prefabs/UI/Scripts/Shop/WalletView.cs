using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour, IInitializable
{
    private TextMeshProUGUI _coinsText;
    private int _coins;
    private MoneyInteractor _interactor;

    private void OnEnable()
    {
        Game.OnGameInitialized += Initialize;
    }

    private void OnDisable()
    {
        Game.OnGameInitialized -= Initialize;
        if (_interactor != null)
            _interactor.MoneyChanged -= SetCoinsView;
    }

    public void Initialize()
    {
        _interactor = Game.GetInteractor<MoneyInteractor>();
        _coinsText = GetComponent<TextMeshProUGUI>();
        _interactor.MoneyChanged += SetCoinsView;
        SetCoinsView(_interactor.Coins); 
    }

    public void SetCoinsView(int coins)
    {
        _coins = coins;
        _coinsText.text = $"Coins: {_coins}";
    }

}

