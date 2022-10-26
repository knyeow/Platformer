using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    [SerializeField] private Animator anim;
    [SerializeField] private ParticleSystem ps;

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null&&collision.GetComponent<Player>().activeCheckpoint !=transform)
        {
           
            ps.Play();
            collision.GetComponent<Player>().activeCheckpoint = transform;
            anim.SetBool("check", true);
            
        }
    }

   
}

