using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour, IInitializable
{
    [SerializeField] private float _startYPosition;
    [SerializeField] private Transform _darkPlane;

    private PlayerInfoInteractor _interactor;

    public void Initialize()
    {
        gameObject.SetActive(false);
        transform.localScale = Vector3.one;
        _interactor = Game.GetInteractor<PlayerInfoInteractor>();
        _interactor.Died += ShowGameOver;
    }

    private void Start()
    {
        var rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, _startYPosition, 0);
        _darkPlane.gameObject.SetActive(false);
        transform.localScale = Vector3.zero;
    }

    private void OnDestroy()
    {
        _interactor.Died -= ShowGameOver;
    }

    private void ShowGameOver()
    {
        gameObject.SetActive(true);
        _darkPlane.gameObject.SetActive(true);
        StartCoroutine(MoveGameOverView());
    }

    private IEnumerator MoveGameOverView()
    {
        var rawImage = _darkPlane.GetComponent<RawImage>();
        var rectTransform = GetComponent<RectTransform>();
        var color = rawImage.color;
        var progress = _startYPosition;

        while (progress >= 0.05)
        {
            progress = Mathf.Lerp(progress, 0f, 0.1f);
            color.a = Mathf.Lerp(color.a, 0.6f, 0.05f);
            rawImage.color = color;
            rectTransform.localPosition = new Vector3(0, progress, 0);
            yield return null;
        }
        StopAllCoroutines();
    }
}

