using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Rendering;
using UnityEngine;

public class PteraEnemy : MonoBehaviour//, IDamageable
{
    #region Variables

    public PteraBaseState currentState;
    public PteraPatrolState patrolState;
    public PteraPlayerDetectedState playerDetectedState;
    public PteraSwoopState pteraSwoopState;
    public PteraAttackState pteraAttackState;
    public StegoDamagedState damagedState;

    public Animator anim;
    public Rigidbody2D rb;
    public Transform ledgeDetector;
    public LayerMask groundLayer, playerLayer, damageableLayer, enemyLayer, pteraLayer;

    public int facingDirection = 1;
    public float stateTime;         

    public EnemyStats stats;
    public int swoopSpeed;
    public float currentHealth;

    #endregion

    #region Callbacks
    private void Awake()
    {
        patrolState = new PteraPatrolState(this, "patrol");
        playerDetectedState = new PteraPlayerDetectedState(this, "playerDetected");
        pteraSwoopState = new PteraSwoopState(this, "swoop");
        pteraAttackState = new PteraAttackState(this, "attack");
        //damagedState = new DamagedState(this, "damaged");  Needs a PteraDamagedState

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
    public bool CheckLedgesAndWalls()
    {
        RaycastHit2D hit = Physics2D.Raycast(ledgeDetector.position, UnityEngine.Vector2.down, stats.cliffCheckDistance, groundLayer);
        RaycastHit2D wallhit = Physics2D.Raycast(ledgeDetector.position, UnityEngine.Vector2.right, stats.wallDistance, groundLayer);

        if (hit.collider == null || wallhit.collider == true)
        {
            return true;
        }
        else
            return false;

    }

    public bool CheckForPlayer()
    {
        RaycastHit2D hitPlayer = Physics2D.Raycast(ledgeDetector.position, facingDirection == 1 ? UnityEngine.Vector2.right : UnityEngine.Vector2.left, stats.playerDetectDistance, playerLayer);

        if (hitPlayer.collider == true)
        {
            return true;
        }
        else
            return false;
    }

    public bool CheckForMeleeTarget()
    {
        RaycastHit2D hitMeleeTarget = Physics2D.Raycast(ledgeDetector.position, facingDirection == 1 ? UnityEngine.Vector2.right : UnityEngine.Vector2.left, stats.meleeDetectDistance, playerLayer);

        if (hitMeleeTarget.collider == true)
        {
            return true;
        }
        else
            return false;
    }

    public void Damage(float damageAmount) { }

   /* public void Damage(float damageAmount, float KBForce, Vector2 KBAngle)
    {
        damagedState.KBForce = KBForce;
        damagedState.KBAngle = KBAngle;
        SwitchState(damagedState);
        currentHealth -= damageAmount;
    }*/

    #endregion
}
