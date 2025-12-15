using System.Collections;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

//using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Player : MonoBehaviour, IDamageable
{

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

    public int extraJumpsValue = 1;
    private int extraJumps;

    private TextMeshProUGUI healthText;

    public AudioClip JumpClip;
    public float perVolume;

    private Rigidbody2D rb;
    private bool isGrounded;

    private float horizontal;
    private bool isFaceingRight = true;

    private AudioSource audiosource;

    private Animator animator;

    private SpriteRenderer spriteRenderer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audiosource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthText = GameObject.FindWithTag("HealthText").GetComponent<TextMeshProUGUI>();
        //damageFlash = GetComponent<DamageFlash>();

        extraJumps = extraJumpsValue;
    }

    void Update()
    {

        if (health <= 0)
        {
            Die();
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        // allows player movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if(isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                PlaySFX(JumpClip);
            }
            else if(extraJumps>0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                extraJumps--;
                PlaySFX(JumpClip);
            }
            
        }

        

        SetAnimation(moveInput);

        Flip();

        HealthImage.fillAmount = health / 100f;
        healthText.text = health.ToString();

        OilImage.fillAmount = oil / 20f;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    public void PlaySFX(AudioClip audioClip)
    {
        audiosource.clip = audioClip;
        audiosource.volume = perVolume/100;
        audiosource.Play();
    }

    private void SetAnimation(float moveInput)
    {
            if(moveInput == 0)
            {
                animator.Play("Player_Idle");
            }
            else
            {
                animator.Play("Player_Walk");
            }

    }

    private void Flip()
    {

        if (isFaceingRight && horizontal < 0f || !isFaceingRight && horizontal > 0f)
        {
            isFaceingRight = !isFaceingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

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

    public void Damage(float damageAmount, float KBForce, Vector2 KBAngle) { }
}
