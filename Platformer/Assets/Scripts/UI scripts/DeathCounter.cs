using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{
    [SerializeField] private Player player;
    private int deathCount;

    private Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        deathCount = player.deathCount;
        text.text = deathCount.ToString();
        
    }

}
