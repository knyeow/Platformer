using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpike : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask wallLayer;

    [SerializeField] private GameObject rightWheel;
    [SerializeField] private GameObject leftWheel;

    private BoxCollider2D bc;
    private Rigidbody2D rb;

    private float timer;

    int a = 1;
    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        

    }

    private void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        StartCoroutine(Spin());

        Debug.Log(rightWheel.transform.localRotation.z);
        if (HasTouched())
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            speed = -speed;
        }
    }



    private bool HasTouched()
    {
        RaycastHit2D checkWall = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size/2, 0f, new Vector2(Mathf.Sign(transform.localScale.x), 0), 1f, wallLayer);
        return checkWall;
    }

    IEnumerator Spin()
    {
        rightWheel.transform.rotation = Quaternion.Euler(0, 0,speed*a*transform.position.x);
        leftWheel.transform.rotation = Quaternion.Euler(0, 0, speed * a*transform.position.x);
        a++;
        yield return new WaitForSeconds(0.01f);
    }
}
