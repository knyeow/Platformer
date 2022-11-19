using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformButton : interactableObjects
{
    [SerializeField] private GameObject platformCreator;
    [SerializeField] private GameObject ButtonInfo;
    private bool isOpen;

    [SerializeField] private Sprite[] Sprites;
    private SpriteRenderer sr;

    protected override void Start()
    {
        base.Start();
        sr = GetComponent<SpriteRenderer>();

    }

    protected override void Update()
    {
        base.Update();

        

        if(gm.isDying && isOpen)
            Close();

        if (SpecificContidion())
            ButtonInfo.SetActive(true);
        else
            ButtonInfo.SetActive(false);


    }


    protected override void Intention()
    {
        if(isOpen)
            Close();
        else
            Open();
    }
    

    protected override bool Trigger()
    {
        return Input.GetKeyDown(KeyCode.F);
    }
    protected override bool SpecificContidion()
    {
        Collider2D isClose = Physics2D.OverlapCircle(transform.position, 2.5f, playerLayer);
        return isClose;

    }

    private void Open()
    {
        sr.sprite = Sprites[1];
        platformCreator.GetComponent<PlatformCreator>().setIsActive();
        isOpen = true;
    }
    private void Close()
    {
        sr.sprite = Sprites[0];
        platformCreator.GetComponent<PlatformCreator>().setIsActive();
        isOpen = false;

    }
}
