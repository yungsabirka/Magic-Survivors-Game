using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusesPanelView : MonoBehaviour, IInitializable
{
    [SerializeField] private List<BonusView> _bonusesViews;

    public event Action<Bonus> BonusSelected;

    private BonusesSpawner _bonusesSpawner;
    private PlayerInfoInteractor _interactor;
    private bool _isPlayerDied;

    public List<BonusView> BonusesView => _bonusesViews;

    private void Start()
    {
        transform.localScale = Vector3.zero;
        foreach (var bonus in _bonusesViews)
            bonus.Clicked += OnBonusSelected;
    }

    public void Initialize()
    {
        _interactor = Game.GetInteractor<PlayerInfoInteractor>();
        _interactor.Died += SetPlayerDeath;
        _bonusesSpawner.BonusesSet += ShowBonuses;
    }

    public void SetBonusesSpawner(BonusesSpawner spawner) => _bonusesSpawner = spawner;

    private void SetPlayerDeath() => _isPlayerDied = true;

    private void OnDestroy()
    {
        _interactor.Died -= SetPlayerDeath;
        _bonusesSpawner.BonusesSet -= ShowBonuses;

        foreach (var bonus in _bonusesViews)
            bonus.Clicked -= OnBonusSelected;
    }

    private void ShowBonuses()
    {
        if (_isPlayerDied)
            return;

        gameObject.SetActive(true);
        Game.PauseHandler.SetPause(true);
        StartCoroutine(ScalePanel());
    }

    public void HideBonuses()
    {
        gameObject.SetActive(false);
        transform.localScale = Vector3.zero;
    }

    private IEnumerator ScalePanel()
    {
        var progress = 0f;
        while (progress <= 0.95)
        {
            progress = Mathf.Lerp(progress, 1, 0.1f);
            transform.localScale = new Vector3 (progress, progress, progress);
            yield return null;
        }
    }

    private void OnBonusSelected(Bonus bonus)
    {
        HideBonuses();
        Game.PauseHandler.SetPause(false);
        bonus.ActiveBonus();
    }
}