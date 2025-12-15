using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;


[CreateAssetMenu(menuName = "EnemyStats")]
public class EnemyStats : ScriptableObject
{

    [Header("General Stats")]
    public float maxHealth = 20;

    [Header("Patrol State")]
    public float speed;
    public float cliffCheckDistance, wallDistance, enemyDistance;

   [Header("Player Detection")]
    public float playerDetectDistance;
    public float detectedPauseTime;
    public float playerDetectedWaitTime;

    [Header("Charge State")]
    public float chargeTime;
    public float chargeSpeed;
    public float meleeDetectDistance;

    [Header("Attack State")]
    public float damageAmount;
    public Vector2 knockbackAngle;
    public float knockbackForce;

    [Header("Base")]
    public float stegoDetectDistance;
    public float stegoAggroCount;
}
