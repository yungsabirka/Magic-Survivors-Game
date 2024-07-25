using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BonusFactory))]
public class BonusesSpawner : MonoBehaviour, IInitializable
{
    [SerializeField] private int _spawnCount;

    public event Action BonusesSet;

    private BonusesPanelView _bonusesPanelView;
    private BonusFactory _factory;
    private List<Bonus> _bonuses;

    public void Initialize()
    {
        if (_bonusesPanelView.BonusesView.Count != _spawnCount)
            throw new Exception("bonuses view count must be equal to spawnCount");

        _factory = GetComponent<BonusFactory>();

        _bonuses = new List<Bonus>();
        Game.GetInteractor<PlayerLevelInteractor>().LevelChanged += SetBonuses;
    }

    public void SetBonusesView(BonusesPanelView bonusesPanelView) 
        => _bonusesPanelView = bonusesPanelView;

    private void OnDisable()
    {
        Game.GetInteractor<PlayerLevelInteractor>().LevelChanged -= SetBonuses;
    }

    public void SetBonuses()
    {
        _bonuses.Clear();
        for (int i = 0; i < _spawnCount; i++)
        {
            bool isBonusRepeat;
            do
            {
                var bonus = GetRandomBonus();

                isBonusRepeat = _bonuses.Contains(bonus);

                if (isBonusRepeat == false)
                    _bonuses.Add(bonus);
            }
            while (isBonusRepeat);
        }

        for (int i = 0; i < _spawnCount; i++)
            _bonusesPanelView.BonusesView[i].SetBonus(_bonuses[i]);

        BonusesSet?.Invoke();
    }

    private Bonus GetRandomBonus()
        => _factory.Get(UnityEngine.Random.Range(0, _factory.BonusesCount));
}