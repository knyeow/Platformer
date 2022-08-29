using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float maxHealth;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [SerializeField] private float dashPower;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCooldown;

    [SerializeField] private ParticleSystem ps;

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private TrailRenderer tr;
    private Animator anim;

    public Transform activeCheckpoint;


    private float horizontal;
    private float vertical;

    private float currentHealth;
    private float damageCooldownTimer;
      
    private bool canDash = true;
    private bool isDashing = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        tr = GetComponent<TrailRenderer>();
        anim = GetComponent<Animator>();


        currentHealth = maxHealth;
       
    }
     void Update()
    {
        
        if (isDashing) return;

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        XScale();
        Walk();
        Jump();
        Dashing();
        Die();

        damageCooldownTimer += Time.deltaTime;

       
    }

    private bool IsGrounded()
    {
        RaycastHit2D groundCheck = Physics2D.BoxCast(transform.GetChild(1).position, new Vector2(bc.bounds.size.x,0.1f), 0f, Vector2.down, 0.1f, groundLayer);
        return groundCheck;
    }

    private void XScale()
    {
        if (horizontal != 0)
            transform.localScale = new Vector2(Mathf.Sign(horizontal) * Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }
    private void Walk()
    {
        if (Mathf.Abs(horizontal) > 0.01f)
        {
            anim.SetBool("Walking", horizontal != 0 ? true : false);
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        }
    }
    private void Jump()
    {

        if (Input.GetKey(KeyCode.Space)&&IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetTrigger("Jump");
        }
    }

    private void Dashing()
    {
        if (Input.GetKey(KeyCode.LeftShift) && canDash)
            StartCoroutine(Dash());
    }
    private IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;
        tr.emitting = true;
        rb.velocity = new Vector2(Mathf.Sign(transform.localScale.x)*dashPower,0);
        yield return new WaitForSeconds(dashTime);
        rb.velocity = Vector2.zero;
        rb.gravityScale = originalGravity;
        isDashing=false;
        tr.emitting = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    public void TakeDamage(float damagePower)
    {
        if (damageCooldownTimer >= 0.1f)
        {
            currentHealth -= damagePower;
            damageCooldownTimer = 0;
        }
    }
    private void Die()
    {
        if (currentHealth <= 0)
        {
            transform.position = activeCheckpoint.position;
            currentHealth = maxHealth;
        }
    }
    
}
