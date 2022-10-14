using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickBomb : MonoBehaviour
{
    [SerializeField] private float x, y;
    [SerializeField] private LayerMask triggerLayers;

    private Vector3 startPosition;

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private Animator anim;
    private ParticleSystem ps;
    private TrailRenderer tr;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        ps = GetComponent<ParticleSystem>();
        tr = GetComponent<TrailRenderer>();
        
        startPosition = transform.position;

        rb.velocity = new Vector2(x, y);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((triggerLayers.value & (1 << collision.gameObject.layer)) > 0)
        {
            StartCoroutine(Stick(collision));
        }
    }




    private IEnumerator Stick(Collision2D collision)
    {
        rb.simulated = false;
        anim.SetBool("boom",true);
        transform.SetParent(collision.transform);
        yield return new WaitForSeconds(3);
        ps.Play();

        transform.SetParent(null);

        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<Player>().TakeDamage(1, 1);

        
        anim.SetBool("boom", false);
        transform.position = startPosition;
        tr.Clear();
        rb.simulated = true;
        rb.velocity = new Vector2(x, y);
        


    }


   

}
