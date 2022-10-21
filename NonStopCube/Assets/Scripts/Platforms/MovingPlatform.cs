using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private LayerMask wallLayer;

    private float speed;

    private int direction = 1;

    private Rigidbody2D rb;
    private BoxCollider2D bc;

    private bool oneTime=false;
    protected virtual void Update()
    {
        if (!oneTime)
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(speed*direction, 0);
            oneTime = true;
        }


        if (IsTouchingWall())
            Destroy(this.gameObject);

        
    }



    private bool IsTouchingWall()
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
