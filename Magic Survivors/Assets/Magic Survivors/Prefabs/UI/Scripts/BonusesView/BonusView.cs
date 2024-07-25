using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BonusView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _imageField;
    [SerializeField] private TextMeshProUGUI _textField;

    private Bonus _bonus;

    public event Action<Bonus> Clicked;

    public void SetBonus(Bonus bonus)
    {
        _bonus = bonus;
        _imageField.sprite = bonus.Sprite;
        _textField.text = bonus.Description;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Clicked?.Invoke(_bonus);
    }
}