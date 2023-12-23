using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, IGetDamage
{
    [SerializeField] private EnemyParameters _enemyParameters;
    [SerializeField] private Image _healthBar;

    private float _maxHealth, _currentHealth;
    
    private void Start()
    {
        _maxHealth = _enemyParameters.health;
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
        
        gameObject.SetActive(false);
    }
}
