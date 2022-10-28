using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameMaster gm;

    [SerializeField] private Animator anim;
    [SerializeField] private ParticleSystem ps;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gm.SetCheckpoint(this.transform.position);
            ps.Play();
            anim.SetBool("check", true);
            
        }
    }

   
}

