using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelView : MonoBehaviour, IInitializable
{
    [SerializeField] private Image _levelBar;
    [SerializeField] private TextMeshProUGUI _levelNumber;

    public void Initialize()
    {
        Game.GetInteractor<PlayerLevelInteractor>().LevelValueChanged += ChangeLevelView;
    }

    private void OnDisable()
    {
        Game.GetInteractor<PlayerLevelInteractor>().LevelValueChanged -= ChangeLevelView;
    }

    private void ChangeLevelView(int level, float currentLevelValue, float nextLevelValue)
    {
        _levelNumber.text = $"{level} lvl";
        _levelBar.fillAmount = currentLevelValue / nextLevelValue;
    }
}

