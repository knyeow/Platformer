using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBomb : MonoBehaviour
{
    [SerializeField] private float x, y;
    [SerializeField] private float power;
    [SerializeField] private float lifeTime;
    [SerializeField] private float delay;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private Animator anim;
    
    [SerializeField] private Transform spawnPoint;
    
    

    private Rigidbody2D rb;
    private BoxCollider2D bc;

    private float bombTimer=0;
    

    private  void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        
        bombTimer = lifeTime-delay;
        transform.position = spawnPoint.position;     
    }

    private void FixedUpdate()
    {
        if (bombTimer >= lifeTime)
            SpawnBomb();

        bombTimer += Time.deltaTime;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D check = Physics2D.OverlapCircle(transform.position, 0.5f, wallLayer);

        if (check)
        {  
            rb.simulated = false;
            StartCoroutine(StickBomb(check));
        }

    }

    private IEnumerator StickBomb(Collider2D collision)
    {
        anim.SetTrigger("Boom");   
         transform.SetParent(collision.transform);    
        yield return new WaitForSeconds(3);
        transform.SetParent(null);
        ps.Play();     
        if(collision.gameObject.CompareTag("Player"))
        collision.GetComponent<Player>().TakeDamage(power,0);
        transform.position = spawnPoint.position;
        GetComponent<TrailRenderer>().Clear();

    }

   
    private void SpawnBomb()
    {
        bombTimer = 0;
        GetComponent<TrailRenderer>().Clear();
        rb.simulated = true;
        rb.velocity = new Vector2(x, y);
    }
  
}


