using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private Transform playerHatPos;


    private Rigidbody2D rb;
    private BoxCollider2D bc;

    public bool isThrow = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        
    }


    public void ThrowHat(Vector2 direction)
    {
        rb.velocity = direction;
        OnGround();
        isThrow = true;
    }

    public void TakeHatBack()
    {
        OnPlayer();
        isThrow = false;
    }

    private void OnGround()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        transform.SetParent(null);
        bc.enabled = true;
    }

    private void OnPlayer()
    {
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.SetParent(player);
        bc.enabled = false;
        transform.position = playerHatPos.position;
    }


}
