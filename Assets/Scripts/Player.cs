using System.Collections;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

//using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Player : MonoBehaviour, IDamageable
{

    public Player_Base currentState;

    [Header("States")]
    public Player_Idle idleState;
    public Player_Jump jumpState;
    public Player_Move moveState;

    public PlayerInput playerInput;

    public float health = 100;
    public int oil = 0;
    public float moveSpeed = 8f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    public Image HealthImage;
    public Image OilImage;

    [Header("Attack Settings")]
    public int damage;
    public float attackRadius = .5f;
    public Transform attackPoint;
    public LayerMask enemyLayer, stegoLayer;

    [Header("Inputs")]
    public Vector2 moveInput;
    public bool walkPressed;
    public bool jumpPressed;

    public int extraJumpsValue = 1;
    public int extraJumps;

    public AudioClip JumpClip;
    public float perVolume;
    
    public bool isGrounded;

    private float horizontal;
    public int isFaceingRight = 1;

    [Header("Components")]
    public Animator animator;
    public Rigidbody2D rb;
    private AudioSource audiosource;
    private SpriteRenderer spriteRenderer;
    private TextMeshProUGUI healthText;



    private void Awake()
    {
        idleState = new Player_Idle(this);
        jumpState = new Player_Jump(this);
        moveState = new Player_Move(this);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audiosource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthText = GameObject.FindWithTag("HealthText").GetComponent<TextMeshProUGUI>();

        ChangeState(idleState);

        extraJumps = extraJumpsValue;
    }

    void Update()
    {
        currentState.Update();
        Flip();

        if (health <= 0)
        {
            Die();
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        
        HealthImage.fillAmount = health / 100f;
        healthText.text = health.ToString();

        OilImage.fillAmount = oil / 20f;
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    public void ChangeState(Player_Base newstate)
    {
        if(currentState != null)
         currentState.Exit();

        currentState = newstate;
        currentState.Enter();
    }

    public void PlaySFX(AudioClip audioClip)
    {
        audiosource.clip = audioClip;
        audiosource.volume = perVolume/100;
        audiosource.Play();
    }


    private void Flip()
    {

        if (moveInput.x >0.1f)
        {
            isFaceingRight = 1;
        }
        else if(moveInput.x < -0.1f)
        {
            isFaceingRight = -1;
        }

        transform.localScale = new Vector3(isFaceingRight, 1, 1);

    }

    private IEnumerator BlinkRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.limeGreen;
    }

    private void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GMNG_4322 V2");
    }

    public void Damage(float damageAmount)
    {
        StartCoroutine(BlinkRed());
        health -= damageAmount;
    }

    public void OnAttack(InputValue value)
    {
        Debug.Log("Player Attacked");
        //animator.Play("Player_Attack");
        
        Collider2D enemy = Physics2D.OverlapCircle(attackPoint.position, attackRadius, enemyLayer);

        IDamageable damageable = enemy.GetComponent<IDamageable>();

        if (damageable != null)
            damageable.Damage(damage, 5, new Vector2(1,1));
        animator.SetBool("Player_Attacl", false);

    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    public void OnJump(InputValue value)
    {
        
    }


    public void Damage(float damageAmount, float KBForce, Vector2 KBAngle) { }
}
