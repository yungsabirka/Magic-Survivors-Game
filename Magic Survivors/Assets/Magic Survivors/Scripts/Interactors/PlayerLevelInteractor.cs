using System;

public class PlayerLevelInteractor : Interactor
{
    public event Action<int, float, float> LevelValueChanged;
    public event Action LevelChanged;

    private PlayerLevelRepository _repository;

    public int Level => _repository.Level;
    public float CurrentLevelValue => _repository.CurrentLevelAmount;
    public float NextLevelValue => _repository.NextLevelAmount;

    public override void OnCreate()
    {
        base.OnCreate();
        _repository = Game.GetRepository<PlayerLevelRepository>();

        void SetStartLevelView()
        {
            LevelValueChanged?.Invoke(_repository.Level, _repository.CurrentLevelAmount, _repository.NextLevelAmount);
            Game.OnGameInitialized -= SetStartLevelView;
        }
        Game.OnGameInitialized += SetStartLevelView;
    }

    public void AddLevelValue(int value)
    {
        if (value <= 0)
            throw new System.Exception("Can not add negative level value");

        _repository.CurrentLevelAmount += value;

        if(_repository.CurrentLevelAmount >= _repository.NextLevelAmount)
        {
            _repository.Level++;
            _repository.CurrentLevelAmount -= _repository.NextLevelAmount;
            _repository.NextLevelAmount *= 1.5f;
            LevelChanged.Invoke();
        }
        LevelValueChanged?.Invoke(_repository.Level, _repository.CurrentLevelAmount, _repository.NextLevelAmount);
    }
}

