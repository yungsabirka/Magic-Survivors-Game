using UnityEngine;

public class MenuView : MonoBehaviour, IInitializable
{
    [SerializeField] private InputController _inputController;
    [SerializeField] private GameObject _darkPlane;

    private PlayerInfoInteractor _interactor;
    private bool _isOpened;
    private bool _isDied;

    private void Start()
    {
        transform.localScale = Vector3.zero; 
    }

    public void Initialize()
    {
        gameObject.SetActive(false);
        transform.localScale = Vector3.one;
        _interactor = Game.GetInteractor<PlayerInfoInteractor>();
        _interactor.Died += SetDeath;
        _inputController.ToggledMenu += ToggleMenu;
    }

    private void OnDestroy()
    {
        _inputController.ToggledMenu -= ToggleMenu;
        _interactor.Died -= SetDeath;
        Game.PauseHandler.SetPause(false);
    }

    public void ToggleMenu()
    {
        if (_isDied)
            return;

        _isOpened = !_isOpened;
        Game.PauseHandler.SetPause(_isOpened);
        gameObject.SetActive(_isOpened);
        _darkPlane.SetActive(_isOpened);
    }

    private void SetDeath() => _isDied = true;

}

