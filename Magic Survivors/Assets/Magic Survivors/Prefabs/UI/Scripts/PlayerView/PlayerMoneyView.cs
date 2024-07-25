using TMPro;
using UnityEngine;

public class PlayerMoneyView : MonoBehaviour, IInitializable
{
    [SerializeField] private TextMeshProUGUI _moneyText;

    public void Initialize()
    {
        Game.GetInteractor<MoneyInteractor>().MoneyChanged += ChangeMoneyView;
    }

    private void OnDisable()
    {
        Game.GetInteractor<MoneyInteractor>().MoneyChanged -= ChangeMoneyView;
    }

    private void ChangeMoneyView(int coins)
    {
        _moneyText.text = $"{coins}";
    }
}

