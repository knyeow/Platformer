using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBomb : Projectile
{
    [SerializeField] private float x, y;

    protected override void Start()
    {
        base.Start();
        rb.velocity = (new Vector2(x, y));
       
    }

    protected override void changeLocation()
    {
        base.changeLocation();
        rb.velocity = (new Vector2(x, y));
    }
    

 }


