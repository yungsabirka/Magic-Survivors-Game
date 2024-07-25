using UnityEngine;

public class CameraMover : MonoBehaviour, IInitializable
{
    private PlayerInfoInteractor _interactor;
    private readonly float _standartPositionZ = -10f;

    public void Initialize()
    {
        _interactor = Game.GetInteractor<PlayerInfoInteractor>();
    }

    private void LateUpdate()
    {
        if (_interactor == null)
            return;

        transform.position = new Vector3(
            _interactor.Position.x, _interactor.Position.y, _standartPositionZ);
    }
}
