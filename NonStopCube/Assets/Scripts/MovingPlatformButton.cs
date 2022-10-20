using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformButton : interactableObjects
{
    [SerializeField] private GameObject platform;

    private bool isOpen;

    



    protected override void Intention()
    {
        if (!isOpen)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 35);
            platform.SetActive(true);
            platform.GetComponent<Platform>().LateStart();
            isOpen = true;
        }else if (isOpen)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -35);
            platform.SetActive(false);
            isOpen = false;
        }

    }

    protected override bool Trigger()
    {
        return Input.GetKeyDown(KeyCode.F);
    }
    protected override bool SpecificContidion()
    {
        Collider2D isClose = Physics2D.OverlapCircle(transform.position, 2f, playerLayer);
        return isClose;

    }

}
