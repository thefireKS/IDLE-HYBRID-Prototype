using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerParameters _playerParameters;

    private bool _canAttack;
    private float _currentAttackTimer = 0f;
    private IGetDamage _damageTarget;
    
    private SphereCollider _sphereCollider;
    
    private void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _sphereCollider.radius = _playerParameters.attackRadius;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy")) return;
        
        _canAttack = true;
        _damageTarget = other.GetComponent<IGetDamage>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Enemy")) return;
        
        _canAttack = false;
        _damageTarget = null;
    }

    private void Update()
    {
        if(!_canAttack) return;

        if (_currentAttackTimer >= _playerParameters.attackSpeed)
        {
            _damageTarget.TakeDamage(_playerParameters.damage);
            _currentAttackTimer = 0f;
        }
        
        _currentAttackTimer += Time.deltaTime;
    }
}
