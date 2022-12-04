using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private LayerMask wallLayer;

    protected float speed;

    protected int direction = 1;

    protected Rigidbody2D rb;
    protected BoxCollider2D bc;

    private bool oneTime=false;
    protected virtual void Update()
    {
        if (!oneTime)
        {
            rb = GetComponent<Rigidbody2D>();
            bc = GetComponent<BoxCollider2D>();
            rb.velocity = new Vector2(speed*direction, 0);
            oneTime = true;
        }


        if (IsTouchingWall())
            Destroy(this.gameObject);

        
    }



    protected bool IsTouchingWall()
    {
        RaycastHit2D check = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 1f, wallLayer);
        return check;

    }

    public void setPlatform(int direction,float speed)
    {
        this.direction = direction;
        this.speed = speed;
    }    

}
