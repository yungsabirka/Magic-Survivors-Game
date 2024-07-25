using UnityEngine;

[CreateAssetMenu(fileName = "TridentBonus", menuName = "Bonuses/TridentBonus")]
public class TridentBonus : Bonus
{
    [SerializeField] private GameObject _tridentPrefab;

    private TridentsInteractor _interactor;

    public override void ActiveBonus()
    {
        if(_interactor == null)
            _interactor = Game.GetInteractor<TridentsInteractor>();

        var tridentCell = _interactor.GetEmptyCell();

        Instantiate(_tridentPrefab, tridentCell);

        if (_interactor.FilledCellsAmount == 1)
            ActiveChildren();

        if (_interactor.AllTridentCellsFilled)
            RemoveBonusFromList();   
    }
}