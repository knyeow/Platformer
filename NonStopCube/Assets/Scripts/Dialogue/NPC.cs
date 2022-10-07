using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;

    private bool oneTime = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&!oneTime)
        {
            dialogueBox.SetActive(true);
            oneTime = true;
        }


    }
}
