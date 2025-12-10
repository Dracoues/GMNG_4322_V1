using System.Collections;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Player : MonoBehaviour
{

    public int health = 100;
    public int oil = 0;
    public float moveSpeed = 8f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Image HealthImage;
    public Image OilImage;

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
    //private DamageFlash damageFlash;


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
        horizontal = Input.GetAxisRaw("Horizontal");

        // allows player movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // allows player jump
        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                extraJumps = extraJumpsValue;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                PlaySFX(JumpClip);
            }
            else if (extraJumps > 0)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            health -= 25;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            StartCoroutine(BlinkRed());
            //damageFlash.CallDamageFlash();

            if (health <= 0)
            {
                Die();
            }
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

}
