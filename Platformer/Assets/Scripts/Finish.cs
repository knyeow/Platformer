using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject finishUI;

    [SerializeField] private Transform finishCheckpoint;

    private bool hasFinished;
    public float levelTimer;
    private GameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();  
    }


    void Update()
    {
        if (!hasFinished)
        levelTimer += Time.deltaTime;


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        FinishLevel();
    }

    private void FinishLevel()
    {
        hasFinished = true;
        gm.SetCheckpoint(finishCheckpoint.position);  //save
        finishUI.SetActive(true);
        gm.onMenu = true;
        Debug.Log(gm.levelTimer);
    }
}
