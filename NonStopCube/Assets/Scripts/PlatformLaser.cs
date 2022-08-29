using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLaser : MonoBehaviour
{
    [SerializeField] private float power;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.GetComponent<Player>().TakeDamage(power);
        
    }

}
