using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Product : MonoBehaviour, IProduct
{
    [SerializeField] private ProductType _type;
    [SerializeField] private float _bonusValue = 0.1f;
    [SerializeField, Range(1, 5)] private int _maxBonusAmount;
    [SerializeField] private int _price;
    [SerializeField] private float _priceIncreaser;

    private string _bonusAmountKey;
    private string _priceKey;
    private int _currentBonusAmount;

    public ProductType Type => _type;
    public float BonusValue => _bonusValue;
    public int CurrentBonusAmount => _currentBonusAmount;
    public int MaxBonusAmount => _maxBonusAmount;
    public int Price => _price;

    private void Awake()
    {
        _bonusAmountKey = $"{name}_{nameof(_currentBonusAmount)}";
        _priceKey = $"{name}_{nameof(_price)}";
        _currentBonusAmount = PlayerPrefs.GetInt(_bonusAmountKey, 0);
        _price = PlayerPrefs.GetInt(_priceKey, _price);
    }

    public void IncreaseProductLevel()
    {
        _currentBonusAmount++;
        _price += (int)(_priceIncreaser * _price);

        PlayerPrefs.SetInt(_bonusAmountKey, _currentBonusAmount);
        PlayerPrefs.SetInt(_priceKey, _price);
    }
}
