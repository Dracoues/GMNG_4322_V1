using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;

public class StegoEnemy : MonoBehaviour
{

    #region Variables
    public StegoBaseState currentState;

    public PatrolState patrolState;
    public PlayerDetectedState playerDetectedState;
    public StegoChargeState stegoChargeState;
    public StegoAttackState stegoAttackState;

    public Animator anim;
    public Rigidbody2D rb;
    public Transform ledgeDetector;
    public Transform stegoDetector;
    public LayerMask groundLayer, playerLayer, damageableLayer, enemyLayer;
    public TagHandle stegoTag;

    public int facingDirection = 1;
    public float stateTime;         //keep track of the time when we enter a new state

    public EnemyStats stats;

    public float stegoCounter;
    

    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        patrolState = new PatrolState(this, "patrolState");
        playerDetectedState = new PlayerDetectedState(this, "playerDetected");
        stegoChargeState = new StegoChargeState(this, "chargeState");
        stegoAttackState = new StegoAttackState(this, "attackState");

        currentState = patrolState;
        currentState.Enter();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    public bool CheckLedgesAndWallsAndStegos()
    {
        RaycastHit2D hit = Physics2D.Raycast(ledgeDetector.position, Vector2.down, stats.cliffCheckDistance, groundLayer);
        RaycastHit2D wallhit = Physics2D.Raycast(ledgeDetector.position, Vector2.right, stats.wallDistance, groundLayer);
        //RaycastHit2D stegohit = Physics2D.Raycast(stegoDetector.position, Vector2.right, stats.enemyDistance, enemyLayer);

        if (hit.collider == null || wallhit.collider == true /*|| (stegohit == true && stegohit.collider == !this)*/)
        {
            return true;
        }
        else
            return false;

    }

    public bool CheckForPlayer()
    {
        RaycastHit2D hitPlayer = Physics2D.Raycast(ledgeDetector.position, facingDirection == 1 ? Vector2.right : Vector2.left, stats.playerDetectDistance, playerLayer);

        if (hitPlayer.collider == true)
        {
            return true;
        }
        else
            return false;
    }

    public bool CheckForMeleeTarget()
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

    public void SwitchState(StegoBaseState newState)
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
    #endregion
}
