using System;

public class MoneyInteractor : Interactor
{
    public event Action<int> MoneyChanged;

    private MoneyRepository _repository;

    public int Coins => _repository.Coins;

    public override void OnCreate()
    {
        base.OnCreate();
        _repository = Game.GetRepository<MoneyRepository>();

        void SetStartMoneyView()
        {
            MoneyChanged?.Invoke(_repository.Coins);
            Game.OnGameInitialized -= SetStartMoneyView;
        }
        Game.OnGameInitialized += SetStartMoneyView;
    }

    public void AddCoins(int value)
    {
        if (value <= 0)
            throw new System.Exception("Can not add negative coins value");

        _repository.Coins += value;
        _repository.Save();
        MoneyChanged?.Invoke(_repository.Coins);
    }

    public void Spend(int value)
    {
        if (value <= 0)
            throw new System.Exception("Can not spend negative coins value");

        _repository.Coins -= value;
        _repository.Save();
        MoneyChanged?.Invoke(_repository.Coins);
    }
}

