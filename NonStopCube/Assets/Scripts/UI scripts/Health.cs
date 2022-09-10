using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Player player;
    
    private Text text;
    private float health;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    

    private void Update()
    {
        health = player.currentHealth;
        text.text = health.ToString();
    }


}
