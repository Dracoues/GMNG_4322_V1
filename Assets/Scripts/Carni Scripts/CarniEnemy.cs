using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;



public class CarniEnemy : MonoBehaviour, IDamageable

{
    #region Variables

    public CarniBaseState currentState;

    public CarniPatrolState patrolState;
    public CarniPlayerDetectedState carniplayerDetectedState;
    public CarniChargeState carniChargeState;
    public CarniAttackState carniAttackState;
    public CarniDamagedState damagedState;

    public Animator anim;
    public Rigidbody2D rb;
    public Transform ledgeDetector;
    public Transform stegoDetector;
    public LayerMask groundLayer, playerLayer, damageableLayer, enemyLayer, carniLayer;
    public TagHandle carniTag;

    public int facingDirection = 1;
    public float stateTime;         //keep track of the time when we enter a new state



    public EnemyStats stats;
    public float currentHealth;

    public float stegoCounter;

    #endregion

    #region Unity Callbacks

    private void Awake()

    {
        patrolState = new CarniPatrolState(this, "patrol");
        carniplayerDetectedState = new CarniPlayerDetectedState(this, "playerDetected");
        carniChargeState = new CarniChargeState(this, "charge");
        carniAttackState = new CarniAttackState(this, "attack");
        damagedState = new CarniDamagedState(this, "damaged");

        currentState = patrolState; 
        currentState.Enter();
    }

    void Start()

    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = stats.maxHealth;
    }

    private void Update()

    { currentState.LogicUpdate(); }

    void FixedUpdate()

    { currentState.PhysicsUpdate(); }
    
    #endregion


    #region Checks

    public bool CheckLedgesAndWallsAndCarnis()

    {
        RaycastHit2D hit = Physics2D.Raycast(ledgeDetector.position, Vector2.down, stats.cliffCheckDistance, groundLayer);
        RaycastHit2D wallhit = Physics2D.Raycast(ledgeDetector.position, Vector2.right, stats.wallDistance, groundLayer);

        if (hit.collider == null || wallhit.collider == true)

        { return true; }

        else
            return false;
    }



    public bool CheckForPlayer()

    {
     RaycastHit2D hitPlayer = Physics2D.Raycast(ledgeDetector.position, facingDirection == 1 ? Vector2.right : Vector2.left, stats.playerDetectDistance, playerLayer);

        if (hitPlayer.collider == true)

        { return true; }

        else
            return false;
    }

    public bool CheckForMeleeTarget()

    {
        RaycastHit2D hitMeleeTarget = Physics2D.Raycast(ledgeDetector.position, facingDirection == 1 ? Vector2.right : Vector2.left, stats.meleeDetectDistance, playerLayer);

        if (hitMeleeTarget.collider == true)

        { return true; }

        else
            return false;

    }

    #endregion

    #region Other Functions

    public void SwitchState(CarniBaseState newState)

    {

        currentState.Exit();
        currentState = newState;
        currentState.Enter();
        stateTime = Time.time;

    }

    public void AnimationFinsihedTrigger()

    { currentState.AnimationFinishedTigger(); }

    public void AnimationAttackTrigger()

    { currentState.AnimationAttackTrigger(); }

    public void Damage(float damageAmount)
    { }

    public void Damage(float damageAmount, float KBForce, Vector2 KBAngle)

    {
        damagedState.KBForce = KBForce;
        damagedState.KBAngle = KBAngle;
        SwitchState(damagedState);
        currentHealth -= damageAmount;
    }

    #endregion

}

