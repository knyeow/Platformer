using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() !=null&& collision.GetComponent<Rigidbody2D>().velocity.y>=0)
        collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x, 9);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x,7);


    }
}
