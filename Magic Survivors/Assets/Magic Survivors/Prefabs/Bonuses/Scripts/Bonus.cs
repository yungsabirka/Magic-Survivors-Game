using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : ScriptableObject
{
    public event Action<Bonus> RemovingBonus;
    public event Action<Bonus> ActivedChildren;

    [SerializeField] private List<Bonus> _children;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _description;

    private bool _isAvailable = true;

    public Sprite Sprite => _sprite;
    public string Description => _description;
    public bool IsAvailable => _isAvailable;
    public IReadOnlyCollection<Bonus> Children => _children;

    public void RemoveBonusFromList()
    {
       RemovingBonus?.Invoke(this);
    }

    public virtual void ActiveChildren()
    {
        ActivedChildren?.Invoke(this);
    }

    public abstract void ActiveBonus();

    public virtual void ResetParameters() { }
}
