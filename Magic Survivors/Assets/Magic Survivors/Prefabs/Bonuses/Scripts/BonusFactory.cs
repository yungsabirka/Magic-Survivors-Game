using System.Collections.Generic;
using UnityEngine;

public class BonusFactory : MonoBehaviour
{
    [SerializeField] private List<Bonus> _bonuses;

    public int BonusesCount => _bonuses.Count;

    private void OnEnable()
    {
        foreach (var bonus in _bonuses)
        {
            bonus.ResetParameters();
            bonus.RemovingBonus += RemoveBonus;

            if (bonus.Children.Count > 0)
                bonus.ActivedChildren += AddBonusChildren;
        }
    }

    private void OnDisable()
    {
        foreach(var bonus in _bonuses)
        {
            bonus.RemovingBonus -= RemoveBonus;

            if (bonus.Children.Count > 0)
                bonus.ActivedChildren -= AddBonusChildren;
        }
    }

    public Bonus Get(int i) => _bonuses[i];

    private void RemoveBonus(Bonus bonus)
    {
        _bonuses.Remove(bonus);

        bonus.RemovingBonus -= RemoveBonus;
    }
    
    private void AddBonusChildren(Bonus bonus)
    {
        foreach(var child in bonus.Children)
        {
            _bonuses.Add(child);
            child.ResetParameters();
            child.RemovingBonus += RemoveBonus;

            if (bonus.Children.Count > 0)
                bonus.ActivedChildren += AddBonusChildren;
        }
        bonus.ActivedChildren -= AddBonusChildren;
    }
}

