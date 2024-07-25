using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Product))]
public class ProductView : MonoBehaviour, IPointerClickHandler
{
    public event Action<Product> Selected, Unselected;

    [SerializeField] private Sprite _sprite;
    [SerializeField] private Transform _bonusAmountContainer;
    [SerializeField] private TextMeshProUGUI _price;

    private List<GameObject> _bonusAmountViews = new();
    private bool _isSelected = false;

    private void Start()
    {
        var product = GetComponent<Product>();
        var currentBonusAmount = product.CurrentBonusAmount;
        var maxBonusAmount = product.MaxBonusAmount;

        SetPriceView(product.Price);

        for (int i = 0; i < maxBonusAmount; i++)
        {
            var bonusAmountView = new GameObject().AddComponent<Image>();
            bonusAmountView.transform.parent = _bonusAmountContainer;
            bonusAmountView.color = currentBonusAmount > i ? Color.white : Color.black;
            bonusAmountView.sprite = _sprite;
            _bonusAmountViews.Add(bonusAmountView.transform.gameObject);
        }
    }

    public void SetPriceView(int price)
    {
        _price.text = $"{price}";
    }

    public void SetIconColor(int currentBonusAmount)
    {
        var icon = _bonusAmountViews[currentBonusAmount - 1].GetComponent<Image>();
        icon.color = Color.white;
    }

    public void Unselect() => _isSelected = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        var product = GetComponent<Product>();
        if (product.CurrentBonusAmount >= product.MaxBonusAmount)
            return;

        var outline = GetComponent<Outline>();
        _isSelected = !_isSelected;

        (_isSelected ? Selected : Unselected)?.Invoke(product);
        outline.enabled = _isSelected;
    }
}
