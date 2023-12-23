using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IGetDamage
{
    [SerializeField] private PlayerParameters _playerParameters;
    [SerializeField] private Image _healthBar;

    private float _maxHealth, _currentHealth;

    private void Start()
    {
        _maxHealth = _playerParameters.health;
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float Damage)
    {
        _currentHealth -= Damage;
        _healthBar.fillAmount = _currentHealth / _maxHealth;
        
        if(_currentHealth <= 0)
            Death();
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
