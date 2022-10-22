using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    private GameObject _platform;
    [SerializeField] private float speed;
    [SerializeField] private int direction;
    [SerializeField] private float coolDown;
    [SerializeField] private bool isActive = true;
    private float coolDownTimer;

    private Animator anim;

    private void Start()
    {
        coolDownTimer = coolDown; 
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        if (coolDownTimer >= coolDown &&isActive)
        {
            anim.SetBool("spawn", true);
            coolDownTimer = 0;
        }

        coolDownTimer += Time.deltaTime;
    }

    private void SpawnPlatform()
    {
       _platform = Instantiate(platform, transform.position, Quaternion.identity,transform);
        _platform.GetComponent<MovingPlatform>().setPlatform(direction,speed);
        anim.SetBool("spawn", false);
    }

    public void setIsActive()
    {
        if (isActive)
            isActive = false;
        else
            isActive = true;
    }
}


