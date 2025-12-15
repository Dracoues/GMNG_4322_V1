using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;

public class StegoEnemy : MonoBehaviour, IDamageable
{

    #region Variables
    public StegoBaseState currentState;

    public PatrolState patrolState;
    public StegoPlayerDetectedState playerDetectedState;
    public StegoChargeState stegoChargeState;
    public StegoAttackState stegoAttackState;
    public StegoDamagedState damagedState;

    public Animator anim;
    public Rigidbody2D rb;
    public Transform ledgeDetector;
    public Transform stegoDetector;
    public LayerMask groundLayer, playerLayer, damageableLayer, enemyLayer, stegoLayer;
    public TagHandle stegoTag;

    public int facingDirection = 1;
    public float stateTime;         //keep track of the time when we enter a new state

    public EnemyStats stats;
    public float currentHealth;

    public StegoDetectionScript stegoDetector;
    
    //public float stegoCounter;
    

    #endregion

    #region Unity Callbacks

    private void Awake() //walkign around
    {
        patrolState = new PatrolState(this, "patrol");
        //playerDetectedState = new PlayerDetectedState(this, "playerDetected");
        stegoChargeState = new StegoChargeState(this, "charge");
        stegoAttackState = new StegoAttackState(this, "attack");
        damagedState = new StegoDamagedState(this, "damaged");
        stegoDetector = GetComponent<StegoDetectionScript>();


        currentState = patrolState; 
        currentState.Enter();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

    #region Checks
    public bool CheckLedgesAndWallsAndStegos() //checks bounds
    {
        RaycastHit2D hit = Physics2D.Raycast(ledgeDetector.position, Vector2.down, stats.cliffCheckDistance, groundLayer);
        RaycastHit2D wallhit = Physics2D.Raycast(ledgeDetector.position, Vector2.right, stats.wallDistance, groundLayer);

        if (hit.collider == null || wallhit.collider == true)
        {
            return true;
        }
        else
            return false;

    }

    public bool CheckForPlayer() //checks player
    {
        RaycastHit2D hitPlayer = Physics2D.Raycast(ledgeDetector.position, facingDirection == 1 ? Vector2.right : Vector2.left, stats.playerDetectDistance, playerLayer);

        if (hitPlayer.collider == true)
        {
            return true;
        }
        else
            return false;
    }

    public bool CheckForMeleeTarget() //checks for target to hit
    {
        RaycastHit2D hitMeleeTarget = Physics2D.Raycast(ledgeDetector.position, facingDirection == 1 ? Vector2.right : Vector2.left, stats.meleeDetectDistance, playerLayer);

        if (hitMeleeTarget.collider == true)
        {
            return true;
        }
        else
            return false;
    }

    #endregion

    #region Other Functions

    public void SwitchState(StegoBaseState newState) //state swaps
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
        stateTime = Time.time;
    }

    public void AnimationFinsihedTrigger()
    {
        currentState.AnimationFinishedTigger();
    }
    public void AnimationAttackTrigger()
    {
        currentState.AnimationAttackTrigger();

    }

    public void Damage(float damageAmount){ }

    public void Damage(float damageAmount, float KBForce, Vector2 KBAngle)
    {
        damagedState.KBForce = KBForce;
        damagedState.KBAngle = KBAngle;
        SwitchState(damagedState);
        currentHealth -= damageAmount;
    }

    #endregion
}
