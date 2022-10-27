using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickBomb : MonoBehaviour
{
    [SerializeField] private float x, y;
    [SerializeField] private LayerMask triggerLayers;

    private Vector3 startPosition;

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private Animator anim;
    private ParticleSystem ps;
    private TrailRenderer tr;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        ps = GetComponent<ParticleSystem>();
        tr = GetComponent<TrailRenderer>();
        
        startPosition = transform.position;

        rb.velocity = new Vector2(x, y);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((triggerLayers.value & (1 << collision.gameObject.layer)) > 0)
        {
            Boom(collision);
        }
    }


    private void Boom(Collision2D collision)
    {
        ps.Play();
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<Player>().Die();
        
        transform.position = startPosition;
        tr.Clear();
        rb.velocity = new Vector2(x, y);
    }

}
