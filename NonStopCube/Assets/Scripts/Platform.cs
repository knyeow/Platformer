using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform:MonoBehaviour{

    [SerializeField] private float speed;
    [SerializeField] private LayerMask wallLayer;

    private Vector3 startPos;
    private float direction;

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        bc= GetComponent<BoxCollider2D>();

        startPos = transform.position;
        rb.velocity = new Vector2(speed, 0);
        direction = Mathf.Sign(speed);
    }


    private void Update()
    {
        if (IsTouchingWall())
            transform.position = startPos;

       
    }

    private bool IsTouchingWall()
    {
        RaycastHit2D check = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 1f, wallLayer);
        return check;

    }

    public void LateStart()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        transform.localPosition = Vector3.zero;
        startPos = transform.position;
        rb.velocity = new Vector2(speed, 0);
        direction = Mathf.Sign(speed);
    }
 
}

