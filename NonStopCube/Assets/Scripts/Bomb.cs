using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Collider2D player;

    private bool isDetected;

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            anim.SetTrigger("Boom");
            isDetected = true;
            player = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            isDetected = false;
            player = null;

        }
    }
    private void Boom()
    {
        if (isDetected)
        {
            player.GetComponent<Player>().TakeDamage(20);
            
        }


    }
}
