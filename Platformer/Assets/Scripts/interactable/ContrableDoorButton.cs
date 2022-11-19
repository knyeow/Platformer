using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrableDoorButton : interactableObjects
{
    [SerializeField] private GameObject door;

    private Vector3 startPos;

    private Rigidbody2D rb;
    private BoxCollider2D bc;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

        startPos = transform.position;

    }


    protected override void Intention()
    {
        if (Istouching())
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            door.GetComponent<Door>().OpenDoor();
        }

        else
        {
            rb.bodyType = RigidbodyType2D.Static;
            transform.position = startPos;
            door.GetComponent<Door>().CloseDoor();
        }
    }

    protected override bool Trigger()
    {
        return true;
    }

    private bool Istouching()
    {
        RaycastHit2D isTouching = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0, Vector2.up, 0.2f, playerLayer);
        return isTouching;
    }



}
