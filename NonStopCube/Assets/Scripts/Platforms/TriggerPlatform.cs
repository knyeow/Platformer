using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatform : MovingPlatform
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<Player>().TakeDamage(1, 0);
    }

}
