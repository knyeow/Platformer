using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableObjects : MonoBehaviour
{
    [SerializeField] protected LayerMask playerLayer;
    [SerializeField] private float coolDown =0.2f;
    private float coolDownTimer =0;

    protected virtual void Update()
    {
        if (Trigger() && SpecificContidion() && coolDownTimer >= coolDown )
        {
            Interact();
            coolDownTimer = 0;
        }

        coolDownTimer += Time.deltaTime;
    }

    protected virtual  bool Trigger()
    {
        return false;
    }

    private void Interact()
    {
        Intention();
    }

    protected virtual void Intention()
    {

    }
    protected virtual bool SpecificContidion()
    {
        return true;
    }
}
