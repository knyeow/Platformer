using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private GameObject hat;
    [SerializeField] private float maxHealth;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [SerializeField] private float dashPower;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCooldown;

    

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private TrailRenderer tr;
    private Animator anim;

    private Hat hatHat;
    

    public Transform activeCheckpoint;


    private float horizontal;
    private float vertical;

    public float currentHealth;
    private float damageCooldownTimer;


    private bool canDash = true;
    private bool isDashing = false;

    private bool isDamageing = false;

    public int deathCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        tr = GetComponent<TrailRenderer>();
        anim = GetComponent<Animator>();

        hatHat = hat.GetComponent<Hat>();

        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        LoadPlayer();
        currentHealth = maxHealth;
       
    }
     private void FixedUpdate()
    {

        Die();
        if (isDamageing) return;
        if (isDashing) return;

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        XScale();
        Walk();
        Jump();  
        Dashing();


        damageCooldownTimer += Time.deltaTime;

    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data =SaveSystem.LoadPlayer();
        deathCount = data.deathCount;
    }

    private bool IsGrounded()
    {
        if (Physics2D.BoxCast(feetPos.position, new Vector2(bc.bounds.size.x, 0.1f), 0f, Vector2.down, 0.1f, groundLayer))
            return true;
        else
            return false;
    }

    private void XScale()
    {
        if (horizontal != 0)
            transform.localScale = new Vector2(Mathf.Sign(horizontal) * Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }
    private void Walk()
    {
        anim.SetBool("Walking", horizontal != 0 ? true : false);
        if (Mathf.Abs(horizontal) > 0.05f)
        {
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        }
    }
    private void Jump()
    {


        if (Input.GetKey(KeyCode.Space) && IsGrounded())
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

    private IEnumerator DamageEffect(float way)
    {
        isDamageing = true;
        rb.velocity = new Vector2(-7*way*Mathf.Sign(transform.localScale.x),7);
        yield return new WaitForSeconds(0.3f);
        rb.velocity = new Vector2(0, rb.velocity.y);
        yield return new WaitForSeconds(0.1f);
        isDamageing = false;

    }

    public void TakeDamage(float damagePower, float way)
    {
        if (damageCooldownTimer >= 0.1f)
        {     
            StartCoroutine(DamageEffect(way));
            currentHealth -= damagePower;
            damageCooldownTimer = 0;

             
        }
    }
    private void Die()
    {
        if (currentHealth <= 0)
        {
            transform.position = activeCheckpoint.position;
            
                hatHat.TakeHatBack();

             rb.velocity = Vector2.zero;
            currentHealth = maxHealth;
            deathCount++;         
            SavePlayer();
        }
    }
    
    

}
