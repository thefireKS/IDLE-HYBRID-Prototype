using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Settings", menuName = "Settings/Enemy Settings")]
public class EnemyParameters : ScriptableObject
{
    [Header("Movement")]
    public float speed;
    [Space(5)]
    
    [Header("Health & Damage")]
    public float health;
    public float damage;
    public float attackSpeed;
    [Tooltip("The radius of the sphere, when entering which the enemy takes damage")]
    public float attackRadius;
    [Space(5)]
    
    [Header("Capturing")]
    public float captureTime;
    [Space(5)] 
    
    [Header("AI")] 
    [Tooltip("Distance from enemy to player, when enemy prioritize the player instead of turrets")]
    public float distanceToPlayer;
}
