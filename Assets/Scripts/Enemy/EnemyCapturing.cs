using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCapturing : MonoBehaviour
{
    private List<TurretCapturing> _turretCapturings = new List<TurretCapturing>();
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Turret"))
            _turretCapturings.Add(other.GetComponent<TurretCapturing>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Turret"))
            _turretCapturings.Remove(other.GetComponent<TurretCapturing>());
    }

    private void OnDisable()
    {
        foreach (var turret in _turretCapturings)
        {
            turret._currentCapturersCount--;
        }
    }
}
