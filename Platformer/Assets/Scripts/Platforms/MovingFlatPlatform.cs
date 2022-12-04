using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFlatPlatform : MovingPlatform
{
    [SerializeField] private LayerMask noPlayer;
    [SerializeField] private LayerMask allLayers;
    [SerializeField] private LayerMask playerLayer;

    private PlatformEffector2D platform;

    private bool isFalling = false;

    private void Start()
    {
        platform = GetComponent<PlatformEffector2D>();
    }

    protected  override void Update()
    {
        base.Update();
        if (CheckPlayer() && !isFalling && Input.GetKey(KeyCode.S))
        {
            StartCoroutine(Fall());
        }

    }

    private  bool CheckPlayer()
    {
        Collider2D isClose = Physics2D.OverlapCircle(transform.position, 2.5f, playerLayer);
        return isClose;

    }

    private IEnumerator Fall()
    {
        isFalling = true;
        platform.colliderMask = noPlayer;
        yield return new WaitForSeconds(0.5f);
        platform.colliderMask = allLayers;
        isFalling = false;
    }

}
