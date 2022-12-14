using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifetime;
    protected float lifetimeTimer=0;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] protected  float power;

    protected Rigidbody2D rb;
    private BoxCollider2D bc;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        lifetimeTimer = lifetime;
    }

    
    protected virtual void FixedUpdate()
    {
        RaycastHit2D check = Physics2D.Raycast(transform.position, new Vector2(transform.localScale.x, 0), 1f, wallLayer);

        if (check || lifetimeTimer >= lifetime)
            changeLocation();

        lifetimeTimer += Time.deltaTime;

    }
   protected virtual void changeLocation()
    {
        lifetimeTimer = 0;
        transform.position = spawnPoint.position;
    }
}
