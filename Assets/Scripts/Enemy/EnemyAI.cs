using System;
using System.Collections.Generic;
using System.Linq;
using Pathfinding;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform _currentTarget;
    [SerializeField] private EnemyParameters _enemyParameters;
    
    private List<TurretCapturing> _turretCapturings = new List<TurretCapturing>();
    
    private IAstarAI _astarAI;
    private AIPath _aiPath;

    private Transform _playerTransform;

    private void OnEnable()
    {
        _astarAI = GetComponent<IAstarAI>();
        _aiPath = GetComponent<AIPath>();

        _aiPath.maxSpeed = _enemyParameters.speed;
        
        _playerTransform = GameObject.FindWithTag("Player").transform;
        foreach (var turret in GameObject.FindGameObjectsWithTag("Turret"))
        {
            _turretCapturings.Add(turret.GetComponent<TurretCapturing>());
            Debug.Log(turret.name);
        }
        
        if (_astarAI != null)
            _astarAI.onSearchPath += Update;
    }

    private void OnDisable()
    {
        if (_astarAI != null)
            _astarAI.onSearchPath -= Update;
    }

    private void Update()
    {
        FindTarget();
    }

    private void FindTarget()
    {
        foreach (var turret in _turretCapturings)
        {
            if(turret._captureData != TurretCapturing.capturedBy.ENEMY && Vector3.Distance(transform.position,turret.transform.position) < Vector3.Distance(transform.position,_currentTarget.position))
                _currentTarget = turret.transform;
        }   

        if (Vector3.Distance(transform.position, _playerTransform.position) < _enemyParameters.distanceToPlayer)
            _currentTarget = _playerTransform;

        _aiPath.destination = _currentTarget.position;
    }
}
