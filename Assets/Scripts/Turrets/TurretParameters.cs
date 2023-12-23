using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Turret Settings", menuName = "Settings/Turret Settings")]
public class TurretParameters : ScriptableObject
{
    [Header("Visuals")] 
    public Color playerColor;
    public Color enemyColor;
    public Material playerMaterial, enemyMaterial;
    [Space(5)]
    
    [Header("Character parameters")]
    public PlayerParameters playerParameters;
    public EnemyParameters enemyParameters;

    [Header("Turret parameters")] 
    public float damage;
    
    public float attackSpeed;
}
