using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ShopView))]
public class Shop : MonoBehaviour
{
    public event Action<int> Unpaid, Paid, PriceChanged;

    [SerializeField] private List<ProductView> _productViews;

    private List<Product> _selectedProducts = new();

    private int _totalPrice;

    private void OnEnable()
    {
        var shopView = GetComponent<ShopView>();
        shopView.Bought += Buy;
        foreach (var productView in _productViews)
        {
            productView.Selected += SelectProduct;
            productView.Unselected += UnselectProduct;
        }
    }

    private void OnDisable()
    {
        var shopView = GetComponent<ShopView>();
        shopView.Bought -= Buy;
        foreach (var productView in _productViews)
        {
            productView.Selected -= SelectProduct;
            productView.Unselected -= UnselectProduct;
        }
    }

    private void SelectProduct(Product product)
    {
        _selectedProducts.Add(product);
        _totalPrice += product.Price;
        PriceChanged?.Invoke(_totalPrice);
    }

    private void UnselectProduct(Product product)
    {
        _selectedProducts.Remove(product);
        _totalPrice -= product.Price;
        PriceChanged?.Invoke(_totalPrice);
    }

    public void Buy()
    {
        if (_selectedProducts.Count == 0)
            return;

        var interactor = Game.GetInteractor<MoneyInteractor>();
        if (interactor.Coins < _totalPrice)
        {
            var priceDifference = _totalPrice - interactor.Coins;
            Unpaid?.Invoke(priceDifference);
            return;
        }

        interactor.Spend(_totalPrice);

        foreach (var product in _selectedProducts)
        {
            var outline = product.GetComponent<Outline>();
            var productView = product.GetComponent<ProductView>();
            product.IncreaseProductLevel();
            productView.Unselect();
            productView.SetPriceView(product.Price);
            productView.SetIconColor(product.CurrentBonusAmount);
            outline.enabled = false;
            ActiveProductBonus(product);
        }
        _selectedProducts.Clear();
        _totalPrice = 0;
        PriceChanged?.Invoke(_totalPrice);
    }

    public void ActiveProductBonus(IProduct product)
    {
        string key = $"{product.Type}";
        var value = product.BonusValue * product.CurrentBonusAmount;
        PlayerPrefs.SetFloat(key, value);
    }
}
