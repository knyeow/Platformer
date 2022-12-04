using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlatform : MovingPlatform
{
    [SerializeField] private LayerMask hatPlayerLayer;

    [SerializeField] private PlatformCreator pc;

    private bool forOnce;

    protected override  void Update()
    {
        base.Update();

        if (checkUp())
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
            rb.velocity = new Vector2(speed * direction, 0);

        if (!forOnce)
        {
            pc = GetComponentInParent<PlatformCreator>();
            pc.setIsActive();
            forOnce = true;
        }

        if (IsTouchingWall())
            pc.setIsActive();
    }

    private bool checkUp()
    {

        RaycastHit2D check = Physics2D.BoxCast(bc.bounds.center + new Vector3(0,bc.bounds.size.y/2,0), new Vector2(bc.bounds.size.x,.1f), 0, Vector2.up, 0.01f, hatPlayerLayer);
        return check;
    }
}
