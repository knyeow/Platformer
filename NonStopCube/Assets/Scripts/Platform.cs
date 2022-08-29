using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float lifetime=5;
    [SerializeField] private float speed;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private GameObject Player;

    private float lifetimeTimer=999;

    private Rigidbody2D rb;
    private BoxCollider2D bc;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();


    }

    void Update()
    {
        Move();
        changeLocation();

       lifetimeTimer += Time.deltaTime;
    }

    private void Move()
    {
        rb.velocity = new Vector2(Mathf.Sign(transform.localScale.x) * speed, 0);
    }

    public void changeLocation()
    {
        RaycastHit2D check = Physics2D.Raycast(transform.position, new Vector2(transform.localScale.x, 0), 1, wallLayer);
        if (check||lifetimeTimer>=lifetime)
        {
            lifetimeTimer = 0;
            transform.position = spawnPoint.position;     
        }
    }

}


