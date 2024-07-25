using UnityEngine;

[CreateAssetMenu(fileName = "MagicBookSpawnerBonus", menuName = "Bonuses/MagicBookSpawnerBonus")]
public class MagicBookSpawnerBonus : Bonus
{
    [SerializeField] private GameObject _magixBookPrefab;

    private MagixBookInteractor _interactor;

    public override void ActiveBonus()
    {
        if (_interactor == null)
            _interactor = Game.GetInteractor<MagixBookInteractor>();

        var startPoint = _interactor.MovingPoints[0];

        Instantiate(_magixBookPrefab, startPoint.position,
            _magixBookPrefab.transform.rotation, startPoint.parent);

        ActiveChildren();
        RemoveBonusFromList();

    }
}