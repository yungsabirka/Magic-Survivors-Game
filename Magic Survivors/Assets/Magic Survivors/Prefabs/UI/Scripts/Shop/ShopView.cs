using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Shop))]    
public class ShopView : MonoBehaviour
{
    public event Action Bought;

    [SerializeField] private TextMeshProUGUI _totalPrice;

    private void OnEnable()
    {
        var shop = GetComponent<Shop>();
        shop.PriceChanged += SetTotalPrice;
    }

    private void OnDisable()
    {
        var shop = GetComponent<Shop>();
        shop.PriceChanged -= SetTotalPrice;
    }

    public void Buy()
    {
        Bought?.Invoke();
    }

    private void SetTotalPrice(int price)
    {
        _totalPrice.text = $"Total price: {price}";
    }
}

