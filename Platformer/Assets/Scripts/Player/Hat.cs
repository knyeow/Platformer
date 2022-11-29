 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{

    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Transform player;

    [SerializeField] private Transform playerHatPos;

    [SerializeField] private GameObject arrow;


    private Rigidbody2D rb;
    [SerializeField]private BoxCollider2D bc;
    private Animator anim;

    public bool isThrow = false;

    private bool isStuck;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    private void Update()
    {
        if (Teleportable())
        {
            arrow.SetActive(true);
            anim.SetBool("teleportable", true);  
        }
        else
        {
            arrow.SetActive(false);
            anim.SetBool("teleportable", false);
        }
        

    }


    public void ThrowHat(Vector2 direction)
    {
        if (isStuck)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
            rb.velocity = new Vector2(direction.x, 0);
        }
        else
            rb.velocity = direction;
        OnAir();
        isThrow = true;
       
    }

    public void TakeHatBack()
    {
        OnPlayer();
        isThrow = false;
    }

    private void OnAir()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        transform.SetParent(null);
        bc.enabled = true;
    }
    public bool Teleportable()
    {
        RaycastHit2D land = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0, Vector2.down, 0.2f, groundLayer);

        if (land&&Mathf.Abs(rb.velocity.y) <0.1f)
            return true;
        else
            return false;
    }


    private void OnPlayer()
    {
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.SetParent(player);
        bc.enabled = false;
        transform.position = playerHatPos.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer==7)
        isStuck = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
            isStuck = false;
    }
}
