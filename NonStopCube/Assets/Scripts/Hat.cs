using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    
    [SerializeField] private Sprite[] hatSprites;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.velocity.x != 0)
        {
            GetComponent<SpriteRenderer>().sprite = hatSprites[1];            
        }
        else
            GetComponent<SpriteRenderer>().sprite = hatSprites[0];


    }
}
