using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Settings", menuName = "Settings/Player Settings")]
public class PlayerParameters : ScriptableObject
{
    [Header("Movement")]
    public float speed;
    [Space(5)]
    
    [Header("Health & Damage")]
    public float health;
    public float damage;
    public float attackSpeed;
    public float attackRadius;
    [Space(5)]
    
    [Header("Capturing")]
    public float captureTime;
}
