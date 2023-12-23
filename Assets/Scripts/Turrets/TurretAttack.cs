using System;
using Unity.VisualScripting;
using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    [SerializeField] private TurretParameters _turretParameters;
    
    private TurretCapturing _turretCapturing;
    private IGetDamage _damageTarget;
    private Transform _damageTargetTransform;

    private float _currentAttackTimer = 0f;
    private void Start()
    {
        _turretCapturing = GetComponent<TurretCapturing>();
    }

    private void Update()
    {
        if(!_turretCapturing._isCaptured) return;
        
        Attack();
    }

    public void SetTurretTarget(TurretCapturing.capturedBy capturedBy)
    {
        _damageTarget = capturedBy switch
        {
            TurretCapturing.capturedBy.ENEMY => GameObject.FindGameObjectWithTag("Player")?.GetComponent<IGetDamage>(),
            TurretCapturing.capturedBy.PLAYER => GameObject.FindGameObjectWithTag("Enemy")?.GetComponent<IGetDamage>(),
            _ => null
        };

        _damageTargetTransform = capturedBy switch
        {
            TurretCapturing.capturedBy.ENEMY => GameObject.FindGameObjectWithTag("Player")?.transform,
            TurretCapturing.capturedBy.PLAYER => GameObject.FindGameObjectWithTag("Enemy")?.transform,
            _ => null
        };
    }

    private void Attack()
    {
        transform.LookAt(_damageTargetTransform);
        
        if (_currentAttackTimer >= _turretParameters.attackSpeed)
        {
            _damageTarget?.TakeDamage(_turretParameters.damage);
            _currentAttackTimer = 0f;
        }
        
        _currentAttackTimer += Time.deltaTime;
    }
}
