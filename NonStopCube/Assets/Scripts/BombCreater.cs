using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCreater : MonoBehaviour
{
    [SerializeField] private GameObject[] greenBombs;

    private void Update()
    {
        SpawnBomb(); 
    }
    private void SpawnBomb()
    {
        for (int i = 0; i < greenBombs.Length; i++)
        {
            if (!greenBombs[i].activeInHierarchy)
                greenBombs[i].SetActive(true);
        }


    }

}
