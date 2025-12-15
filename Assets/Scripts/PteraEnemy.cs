using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Rending;
using UnityEngine;

public class PteraEnemy : MonoBehaviour, IDamageable
{
    #region Variables

    public PteraBaseState currentState;
    public PatrolState patrolState;
    public PlayerDetectedState playerDetectedState;
    public PteraSwoop pteraSwoopState;
    public PteraAttack pteraAttackState;
    public DamagedState damagedState;

    public Animator anim;
    public Rigidbody2D rb;
    public Transform ledgeDetector;
    public LayerMask groundLayer, playerLayer, damageableLayer, enemyLayer;

    public int facingDirection = 1;
    public float stateTime;         

    public EnemyStats stats;
    public float currentHealth;

    #endregion

    #region Callbacks
    private void Ptera()
    {
        patrolState = new PatrolState(this, "patrol");
        playerDetectedState = new PlayerDetectedState(this, "playerDetected");
        pteraSwoop = new PteraSwoopState(this, "swoop");
        pteraAttack = new PteraAttackState(this, "attack");
        damagedState = new DamagedState(this, "damaged");

        currentState = patrolState;
        currentState.Enter();
    }

    private void Start()
    {
        rb = GetComponent < Rigidbody2D>();
        currentHealth = stats.maxHealth;

    }

    private void Update()
    {
        currentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        currentState.PhysicsUpdate();
    }

    #endregion

    #region OtherFunctions

    public void SwitchState(PteraBaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
        stateTime = Time.time;
    }

    public void AnimationFinishedTrigger()
    {
        currentState.AnimationFinishedTigger();
    }
    public void AnimationAttackTrigger()
    {
        currentState.AnimationAttackTrigger();

    }

    public void Damage(float damageAmount) { }

    public void Damage(float damageAmount, float KBForce, Vector2 KBAngle)
    {
        damagedState.KBForce = KBForce;
        damagedState.KBAngle = KBAngle;
        SwitchState(damagedState);
        currentHealth -= damageAmount;
    }

    #endregion
}
