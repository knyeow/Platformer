using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformButton : interactableObjects
{
    [SerializeField] private GameObject platformCreator;

    private bool isOpen;

    



    protected override void Intention()
    {
        if (!isOpen)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 35);
            platformCreator.GetComponent<PlatformCreator>().setIsActive();
            isOpen = true;
        }else if (isOpen)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -35);
            platformCreator.GetComponent<PlatformCreator>().setIsActive();
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
