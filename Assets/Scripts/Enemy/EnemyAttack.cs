using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemyParameters _enemyParameters;

    private bool _canAttack;
    private float _currentAttackTimer = 0f;
    private IGetDamage _damageTarget;
    
    private SphereCollider _sphereCollider;
    
    
    private void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _sphereCollider.radius = _enemyParameters.attackRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _canAttack = true;
        _damageTarget = other.GetComponent<IGetDamage>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        _canAttack = false;
        _damageTarget = null;
    }

    private void Update()
    {
        if(!_canAttack) return;

        if (_currentAttackTimer >= _enemyParameters.attackSpeed)
        {
            _damageTarget.TakeDamage(_enemyParameters.damage);
            _currentAttackTimer = 0f;
        }
        
        _currentAttackTimer += Time.deltaTime;
    }
}
