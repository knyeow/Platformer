using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : Projectile
{
    private Projectile projectile;

    [SerializeField] private float speed;
 

    protected override void Update()
    {
        base.Update();
        Move();

    }

    private void Move()
    {
        rb.velocity = new Vector2(Mathf.Sign(transform.localScale.x) * speed, 0);
    }

}


