using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBomb : MonoBehaviour
{
    [SerializeField] private float x, y;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.V))
            rb.AddForce(new Vector2(x, y));

    }

}
