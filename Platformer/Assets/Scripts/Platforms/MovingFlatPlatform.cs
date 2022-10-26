using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFlatPlatform : MovingPlatform
{
    [SerializeField] private LayerMask noPlayer;
    [SerializeField] private LayerMask allLayers;

    private float waitTime;
    private PlatformEffector2D platform;

    private void Start()
    {
        platform = GetComponent<PlatformEffector2D>();
    }

    protected override void Update()
    {
        base.Update();


        if (Input.GetKeyUp(KeyCode.S))
        {
            waitTime = -0.1f;
        }



        if (Input.GetKey(KeyCode.S))
        {
            StartCoroutine(Fall());
        }

    }


    private IEnumerator Fall()
    {
        platform.colliderMask = noPlayer;
        yield return new WaitForSeconds(0.2f);
        platform.colliderMask = allLayers;
    }

}
