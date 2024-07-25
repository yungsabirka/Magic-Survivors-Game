using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthView : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    
    private Image _healthBar;

    private void Awake()
    {
        _healthBar = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _enemyHealth.HealthChanged += ChangeHealthView;
    }
    private void OnDisable()
    {
        _enemyHealth.HealthChanged -= ChangeHealthView;
    }
    private void ChangeHealthView(int health, int maxHealth)
    {
        _healthBar.fillAmount = (float)health / maxHealth;
    }
}
