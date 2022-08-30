using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBomb : Projectile
{
    [SerializeField] private float x, y;
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private Animator anim;

    private float bombTimer=8;

    protected override void Start()
    {
        base.Start();

        rb.velocity = (new Vector2(x, y));
    }

    protected override void Update()
    {
        base.Update();
        bombTimer += Time.deltaTime;
       
    }

    protected override void changeLocation()
    {
        base.changeLocation();
        rb.velocity = (new Vector2(x, y));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && bombTimer > 5)
        {
            
            bombTimer = 0;
            StartCoroutine(StickBomb(collision));
        }

    }

    private IEnumerator StickBomb(Collider2D collision)
    {
        anim.SetTrigger("Boom");
        lifetimeTimer = 0;
        rb.velocity = Vector2.zero;
        transform.SetParent(collision.transform);
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.simulated = false;   
        yield return new WaitForSeconds(3);
        transform.SetParent(null);
        ps.Play();   
        yield return new WaitForSeconds(0.1f);
        collision.GetComponent<Player>().TakeDamage(power);
        changeLocation();
        rb.simulated = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
   
}


