using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    private GameMaster gm;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private GameObject hat;
    [SerializeField] private float maxHealth;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [SerializeField] private float dashPower;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCooldown;

    [SerializeField] private PhysicsMaterial2D noFriction;

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


    public static bool isDying = false;


    public int deathCount = 0;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
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
        if (isDying) return;
        if (isDashing) return;
        

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        XScale();
        Walk();

        if (Input.GetKey(KeyCode.Space) && IsGrounded())
            Jump();

        if (Input.GetKey(KeyCode.LeftShift) && canDash)
            StartCoroutine(Dash());

        

        if (!IsGrounded())
            rb.sharedMaterial = noFriction;
        else
            rb.sharedMaterial = null;

            anim.SetBool("jump", !IsGrounded());

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Die();
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
        anim.SetBool("Walking", Mathf.Abs(horizontal) > 0.05f);
        if (Mathf.Abs(horizontal) > 0.1f)
        {
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        }
    }
    private void Jump()
    {
          rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    private IEnumerator Dash()
    {
        isDashing = true;
        anim.SetBool("isDashing", true);
        canDash = false;
        Vector2 originalCollider = new Vector2(bc.offset.y, bc.size.y);
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;
        bc.offset = new Vector2(bc.offset.x, -0.1700975f);
        bc.size = new Vector2(bc.size.x, 0.3998051f);
        tr.emitting = true;
        rb.velocity = new Vector2(Mathf.Sign(transform.localScale.x)*dashPower,0);
        yield return new WaitForSeconds(dashTime);
        rb.velocity = Vector2.zero;
        rb.gravityScale = originalGravity;
        bc.offset = new Vector2(bc.offset.x, originalCollider.x);
        bc.size = new Vector2(bc.size.x, originalCollider.y);
        isDashing =false;
        anim.SetBool("isDashing", false);
        tr.emitting = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    public void Die()
    {
        if(!isDying)
        StartCoroutine(DieRoutine());
    }
    
    public IEnumerator DieRoutine()
    {
        rb.simulated = false;
        isDying = true;
        anim.SetBool("splitDie", true);
        yield return new WaitForSeconds(1.5f);
        transform.position = gm.GetCheckpoint();
        hatHat.TakeHatBack();
        rb.velocity = Vector2.zero;
        deathCount++;
        SavePlayer();
        isDying=false;
        anim.SetBool("splitDie", false);
        rb.simulated = true;

    }

}
